using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApplication1
{
    internal class Cashier : UserAccount
    {
        private string department;

        
        public Cashier(string name, string department, string uName, string password)
            : base(name, uName, password)
        {
            this.department = department;
        }

        public new bool validateLogin(string uName, string password)
        {
            return (user_name == uName && user_password == password);
        }

        public string getDepartment()
        {
            return department;
        }
    }
}
