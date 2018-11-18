using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using RestServices.Models;

namespace RestServices
{
    public class CrazyMelvinDAL
    {
        private string connString = "Data Source=2A314-E04;Persist Security Info=False;User ID=SA; Password=Conestoga1;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=6;Encrypt=False;TrustServerCertificate=True; Initial Catalog=SOA4DB";
        private SqlConnection conn;

        public CrazyMelvinDAL()
        {
            conn = new SqlConnection(connString);
        }

        

        public IEnumerable<Customer> GetCustomersByQuery(Dictionary<string,string> query = null)
        {
            List<Customer> customers = new List<Customer>();

            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = CustomerSelect;

            if (query != null && query.Keys.Count > 0)
            {
                com.CommandText += QueryToWhere(query);
            }
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(ReadCustomer(reader));
                }
            }
            conn.Close();
            return customers;
        }
        public IEnumerable<Product> GetProductsByQuery(Dictionary<string, string> query = null)
        {
            List<Product> products = new List<Product>();
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = ProductSelect;

            if (query != null && query.Keys.Count > 0)
            {
                com.CommandText += QueryToWhere(query);
            }
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(ReadProduct(reader));
                }
            }
            conn.Close();
            return products;
        }
        public IEnumerable<Order> GetOrdersByQuery(Dictionary<string, string> query = null)
        {
            List<Order> orders = new List<Order>();
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = OrderSelect;
            if (query != null && query.Keys.Count > 0)
            {
                com.CommandText += QueryToWhere(query);
            }
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(ReadOrder(reader));
                }
            }
            conn.Close();
            return orders;
        }
        public IEnumerable<Cart> GetCartsByQuery(Dictionary<string, string> query = null)
        {
            List<Cart> carts = new List<Cart>();
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = CartSelect;
            if (query != null && query.Keys.Count > 0)
            {
                com.CommandText += QueryToWhere(query);
            }
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    carts.Add(ReadCart(reader));
                }
            }
            conn.Close();
            return carts;
        }

		public IEnumerable<PurchaseOrder> GetPurchaseOrdersByQuery(Dictionary<string, string> query)
		{
			List<PurchaseOrder> purchase_orders = new List<PurchaseOrder>();
			conn.Open();
			SqlCommand com = conn.CreateCommand();
			com.CommandText = CustomerSelect;
			return purchase_orders;
		}

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetCustomersByQuery();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return GetProductsByQuery();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return GetOrdersByQuery();
        }
        public IEnumerable<Cart> GetAllCarts()
        {
            return GetCartsByQuery();
        }

        public bool InsertCustomer(Customer customer)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO tblCustomer (firstName, lastName, phoneNumber) VALUES (@firstName, @lastName, @phoneNumber);";
            com.Parameters.AddWithValue("@firstName", customer.firstName);
            com.Parameters.AddWithValue("@lastName", customer.lastName);
            com.Parameters.AddWithValue("@phoneNumber", customer.phoneNumber);

            int result = com.ExecuteNonQuery();
            conn.Close();
            return result == 1 ? true : false;
        }
        public bool InsertProduct(Product product)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO tblProduct (prodName, price, prodWeight, inStock) VALUES (@prodName, @price, @prodWeight, @inStock);";
            com.Parameters.AddWithValue("@prodname", product.prodName);
            com.Parameters.AddWithValue("@price", product.price);
            com.Parameters.AddWithValue("@prodWeight", product.prodWeight);
            com.Parameters.AddWithValue("@inStock", product.inStock);

            int result = com.ExecuteNonQuery();
            conn.Close();
            return result == 1 ? true : false;
        }
        public bool InsertOrder(Order order)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO tblOrder (custId, orderDate, poNumber) VALUES (@custId, @orderDate, @poNumber);";
            com.Parameters.AddWithValue("@custId", order.custId);
            com.Parameters.AddWithValue("@orderDate", order.orderDate);
            com.Parameters.AddWithValue("@poNumber", order.poNumber);

            int result = com.ExecuteNonQuery();
            conn.Close();
            return result == 1 ? true : false;
        }
        public bool InsertCart(Cart cart)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO tblOrder (orderId, prodId, quantity) VALUES (@orderId, @prodId, @quantity);";
            com.Parameters.AddWithValue("@orderId", cart.orderId);
            com.Parameters.AddWithValue("@prodId", cart.prodId);
            com.Parameters.AddWithValue("@quantity", cart.quantity);

            int result = com.ExecuteNonQuery();
            conn.Close();
            return result == 1 ? true : false;
        }

        public bool DeleteCustomer(int custId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblCustomer WHERE custId=@custId;";
            com.Parameters.AddWithValue("@custId", custId);
            int result = com.ExecuteNonQuery();

            return result == 1 ? true : false;
        }
        public bool DeleteProduct (int prodId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblProduct WHERE prodId=@prodId;";
            com.Parameters.AddWithValue("@prodId", prodId);
            int result = com.ExecuteNonQuery();

            return result == 1 ? true : false;
        }
        public bool DeleteOrder(int orderId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblOrder WHERE orderId=@orderId;";
            com.Parameters.AddWithValue("@orderId", orderId);
            int result = com.ExecuteNonQuery();

            return result == 1 ? true : false;
        }
        public bool DeleteOrderByCustomer(int custId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblOrder WHERE custId=@custId;";
            com.Parameters.AddWithValue("@custId", custId);
            int result = com.ExecuteNonQuery();

            return result >= 1 ? true : false;
        }
        public bool DeleteCart(int orderId, int prodId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblCart WHERE orderId=@orderId AND prodId=@prodId;";
            com.Parameters.AddWithValue("@orderId", orderId);
            com.Parameters.AddWithValue("@prodId", prodId);
            int result = com.ExecuteNonQuery();

            return result == 1 ? true : false;
        }
        public bool DeleteCartsByOrder(int orderId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblCart WHERE orderId=@orderId;";
            com.Parameters.AddWithValue("@orderId", orderId);
            int result = com.ExecuteNonQuery();

            return result >= 1 ? true : false;
        }
        public bool DeleteCartsByProduct(int prodId)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "DELETE FROM tblCart WHERE prodId=@prodId;";
            com.Parameters.AddWithValue("@prodId", prodId);
            int result = com.ExecuteNonQuery();

            return result >= 1 ? true : false;
        }

        public bool UpdateCustomer(Customer cust)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "UPDATE tblCustomer SET firstName=@firstName, lastName=@lastName, phoneNumber=@phoneNumber WHERE custId=@custId;";
            com.Parameters.AddWithValue("@firstName", cust.firstName);
            com.Parameters.AddWithValue("@lastName", cust.lastName);
            com.Parameters.AddWithValue("@phoneNumber", cust.phoneNumber);
            com.Parameters.AddWithValue("@custId", cust.custId);

            int result = com.ExecuteNonQuery();
            return result == 1 ? true : false;
        }
        public bool UpdateProduct(Product prod)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "UPDATE tblProduct SET prodName=@prodName, price=@price, prodWeight=@prodWeight, inStock=@inStock WHERE prodId=@prodId;";
            com.Parameters.AddWithValue("@prodName", prod.prodName);
            com.Parameters.AddWithValue("@price", prod.price);
            com.Parameters.AddWithValue("@prodWeight", prod.prodWeight);
            com.Parameters.AddWithValue("@inStock", prod.inStock);
            com.Parameters.AddWithValue("@prodId", prod.prodId);

            int result = com.ExecuteNonQuery();
            return result == 1 ? true : false;
        }
        public bool UpdateOrder(Order order)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "UPDATE tblOrder SET custId=@custId, orderDate=@orderDate, poNumber=@poNumber WHERE orderId=@orderId;";
            com.Parameters.AddWithValue("@orderId", order.orderId);
            com.Parameters.AddWithValue("@custId", order.custId);
            com.Parameters.AddWithValue("@orderDate", order.orderDate);
            com.Parameters.AddWithValue("@poNumber", order.poNumber);

            int result = com.ExecuteNonQuery();
            return result == 1 ? true : false;
        }
        public bool UpdateCart(Cart cart)
        {
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = "UPDATE tblCart SET quantity=@quantity WHERE orderId=@orderId AND prodId=@prodId;";
            com.Parameters.AddWithValue("@orderId", cart.orderId);
            com.Parameters.AddWithValue("@prodId", cart.prodId);
            com.Parameters.AddWithValue("@quantity", cart.quantity);

            int result = com.ExecuteNonQuery();
            return result == 1 ? true : false;
        }

        private string QueryToWhere(Dictionary<string, string> query)
        {
            string Where = " WHERE ";
            foreach (KeyValuePair<string, string> constraint in query)
            {
                Where += constraint.Key + "=@" + constraint.Key + " AND ";
            }

            Where = Where.Substring(0, Where.Length - 4);
            return Where;
        }

        #region Data Reading Helpers

        private const string CustomerSelect = "SELECT custId, firstName, lastName, phoneNumber FROM tblCustomer ";
        private Customer ReadCustomer(SqlDataReader reader)
        {
            Customer cust = new Customer();
            cust.custId = reader.GetInt32(0);
            cust.firstName = reader.GetTextReader(1).ReadToEnd();
            cust.lastName = reader.GetTextReader(2).ReadToEnd();
            cust.phoneNumber = reader.GetTextReader(3).ReadToEnd();
            return cust;
        }

        private const string ProductSelect = "SELECT prodId, prodName, price, prodWeight, inStock FROM tblProduct ";
        private Product ReadProduct(SqlDataReader reader)
        {
            Product prod = new Product();
            prod.prodId = reader.GetInt32(0);
            prod.prodName = reader.GetTextReader(1).ReadToEnd();
            prod.price = reader.GetDecimal(2);
            prod.prodWeight = reader.GetDecimal(3);
            prod.inStock = reader.GetBoolean(4);
            return prod;
        }

        private const string OrderSelect = "SELECT orderId, custId, orderDate, poNumber FROM tblOrder ";
        private Order ReadOrder(SqlDataReader reader)
        {
            Order order = new Order();
            order.orderId = reader.GetInt32(0);
            order.custId = reader.GetInt32(1);
            order.orderDate = reader.GetDateTime(2);
            order.poNumber = reader.GetTextReader(3).ReadToEnd();
            return order;
        }

        private const string CartSelect = "SELECT orderId, prodId, quantity FROM tblCart ";
        private Cart ReadCart(SqlDataReader reader)
        {
            Cart cart = new Cart();
            cart.orderId = reader.GetInt32(0);
            cart.prodId = reader.GetInt32(1);
            cart.quantity = reader.GetInt32(2);
            return cart;
        }

        #endregion
    }
}