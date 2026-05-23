using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApplication1
{
    internal class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        
        public DiscountedItem(string name, double price, int quantity, double discount)
            : base(name, price, quantity)
        {
            item_discount = discount;
        }

        
        public new double getTotalPrice()
        {
            double result = item_discount * 0.01;        
            discounted_price = item_price * result;       
            double finalPrice = item_price - discounted_price; 
            total_price = finalPrice * item_quantity;
            return total_price;
        }

       
        public new void setPayment(double amount)
        {
            payment_amount = amount;
        }

       
        public double getChange()
        {
            change = payment_amount - total_price;
            return change;
        }
    }
}
