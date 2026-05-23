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
    public partial class frmLoginAccount : Form
    {
        private Cashier cashier = new Cashier("Clarisa Castro", "Finance", "cashier101", "password123");
        public frmLoginAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your username.",
                    "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // Check if password is empty
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter your password.",
                    "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // Check minimum length for username
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.",
                    "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            // Check minimum length for password
            if (textBox2.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
                textBox2.Focus();
                return;
            }

            string uName = textBox1.Text;
            string password = textBox2.Text;

            // Validate login
            if (cashier.validateLogin(uName, password))
            {
                string fullName = cashier.getFullName();
                string dept = cashier.getDepartment();
                MessageBox.Show("Welcome " + fullName + " of " + dept,
                    "", MessageBoxButtons.OK, MessageBoxIcon.None);

                frmPurchaseDiscountedItem mainForm = new frmPurchaseDiscountedItem(this);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
