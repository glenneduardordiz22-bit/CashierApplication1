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
        private frmLoginAccount loginForm;

        public frmPurchaseDiscountedItem(frmLoginAccount login)
        
            {
            InitializeComponent();
            loginForm = login;

           
            label5.Text = "Total amount:    0.00";
            label7.Text = "Change:    0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                 string.IsNullOrWhiteSpace(textBox2.Text) ||
                 string.IsNullOrWhiteSpace(textBox3.Text) ||
                 string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields before computing.",
                    "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox2.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Price.",
                    "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
                return;
            }

            if (!double.TryParse(textBox3.Text, out double discount) ||
                discount < 0 || discount > 100)
            {
                MessageBox.Show("Please enter a valid discount between 0 and 100.",
                    "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();
                textBox3.Focus();
                return;
            }

            if (!int.TryParse(textBox4.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive whole number for Quantity.",
                    "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
                textBox4.Focus();
                return;
            }

            string name = textBox1.Text;

            DiscountedItem di = new DiscountedItem(name, price, quantity, discount);
            double total = di.getTotalPrice();

            label5.Text = "Total amount:    " + total.ToString("F2");
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Total amount:    0.00" || string.IsNullOrWhiteSpace(label5.Text))
            {
                MessageBox.Show("Please click Compute first before submitting.",
                    "Compute First", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter the payment amount.",
                    "Missing Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }

            if (!double.TryParse(textBox2.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Price.",
                    "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox3.Text, out double discount) ||
                discount < 0 || discount > 100)
            {
                MessageBox.Show("Please enter a valid discount between 0 and 100.",
                    "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox4.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive whole number for Quantity.",
                    "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox5.Text, out double payment) || payment <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Payment.",
                    "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Clear();
                textBox5.Focus();
                return;
            }

            string name = textBox1.Text;

            DiscountedItem di = new DiscountedItem(name, price, quantity, discount);
            double total = di.getTotalPrice();

            if (payment < total)
            {
                MessageBox.Show($"Payment of {payment:F2} is not enough.\n" +
                    $"Total amount is {total:F2}. Please enter a higher payment.",
                    "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Clear();
                textBox5.Focus();
                return;
            }

            di.setPayment(payment);
            double change = di.getChange();

            label7.Text = "Change:    " + change.ToString("F2");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label5.Text = "Total amount:    0.00";
            label7.Text = "Change:    0.00";

            loginForm.Show();
            this.Hide();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
