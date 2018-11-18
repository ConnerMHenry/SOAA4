using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
	public class PurchaseOrder
	{
		public Customer customer;
		public Order order;
		public IEnumerable<Cart> carts;
		public Dictionary<int, Product> products;
		public Decimal subTotal;
		public Decimal tax;
		public Decimal total;
		public int pieces;
		public Decimal weight;

		public void CalculateTotals()
		{
			subTotal = 0;
			tax = 0;
			total = 0;
			pieces = 0;
			weight = 0;
			foreach (Cart cart in carts)
			{
				if (products[cart.prodId].inStock)
				{
					subTotal += cart.quantity * products[cart.prodId].price;
					pieces += cart.quantity;
					weight += cart.quantity * products[cart.prodId].prodWeight;
				}
			}
			tax = subTotal * 0.13m;
			total = subTotal + tax;
		}
	}
}