using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    public class Customer
    {
        private string name;
        private string surname;
        private decimal debt;
        private DateTime date;

        public Customer(string Name, string Surname, decimal Debt, DateTime Date)
        {
            this.name = Name;
            this.surname = Surname;
            this.debt = Debt;
            this.date = Date;
        }

    }
}
