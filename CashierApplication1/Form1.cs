using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication1
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        public frmPurchaseDiscountedItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;               
            double price = Convert.ToDouble(textBox2.Text);   
            double discount = Convert.ToDouble(textBox3.Text); 
            int quantity = Convert.ToInt32(textBox4.Text);     

            DiscountedItem di = new DiscountedItem(name, price, quantity, discount);

            double total = di.getTotalPrice();
            label5.Text = "Total amount:    " + total.ToString("F2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            double price = Convert.ToDouble(textBox2.Text);
            double discount = Convert.ToDouble(textBox3.Text);
            int quantity = Convert.ToInt32(textBox4.Text);
            double payment = Convert.ToDouble(textBox5.Text);  

            DiscountedItem di = new DiscountedItem(name, price, quantity, discount);
            di.getTotalPrice(); 
            di.setPayment(payment);

            double change = di.getChange();
            label7.Text = "Change:    " + change.ToString("F2");
        }

        
    }
}
