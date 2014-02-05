using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystemProject
{
    public abstract class Account
    {
        private CustomerType customer;
        private decimal balance;
        private decimal interestRate;

        public Account(CustomerType customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public CustomerType Customer
        {
            get { return this.customer; }
            protected set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0M)
                {
                    throw new ArgumentOutOfRangeException("Balance in account can not be negative number!");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate 
        {
            get { return this.interestRate; }
            protected set
            {
                if (value < 0M)
                {
                    throw new ArgumentOutOfRangeException("Interest rate can not be negative number!");
                }

                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterestAmount();

        public override string ToString()
        {
            return string.Format("{0}, customer type: {1}, balance: {2}", this.GetType().Name, this.Customer, this.Balance);
        }
    }
}
