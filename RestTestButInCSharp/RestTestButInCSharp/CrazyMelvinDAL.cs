using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using RestTestButInCSharp.Models;

namespace RestTestButInCSharp
{
    public class CrazyMelvinDAL
    {
        

        private string connString = "Data Source=2A314-E06;Persist Security Info=False;User ID=SA;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True; Initial Catalog=SOA4DB";
        private SqlConnection conn;

        public CrazyMelvinDAL()
        {
            conn = new SqlConnection(connString);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = CustomerSelect;
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.NextResult())
                {
                    customers.Add(ReadCustomer(reader));
                }
            }
            conn.Close();
            return customers;
        }

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

        private const string CartSelect = "SELECT orderId, prodId, quantity FROM tblOrder ";
        private Cart ReadCart(SqlDataReader reader)
        {
            Cart cart = new Cart();
            cart.orderId = reader.GetInt32(0);
            cart.prodId = reader.GetInt32(1);
            cart.quantity = reader.GetInt32(2);
            return cart;
        }
    }
}