using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApplication1
{
    internal class Item
    {
        protected string item_name;
        protected double item_price;
        protected int item_quantity;
        protected double total_price;

      
        public Item(string name, double price, int quantity)
        {
            item_name = name;
            item_price = price;
            item_quantity = quantity;
        }

        public double getTotalPrice()
        {
            total_price = item_price * item_quantity;
            return total_price;
        }

        public void setPayment(double amount)
        {
           
        }
    }
}
