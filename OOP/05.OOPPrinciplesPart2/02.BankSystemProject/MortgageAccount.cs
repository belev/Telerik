using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystemProject
{
    public class MortgageAccount : Account, IDepositable
    {
        private int mortgagePeriod;
        public MortgageAccount(CustomerType customer, decimal balance, decimal interestRate, int mortgagePeriod)
            : base(customer, balance, interestRate)
        {
            this.mortgagePeriod = mortgagePeriod;
        }

        public int MortgagePeriod
        {
            get { return this.mortgagePeriod; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Mortgage period can't be zero or negative!");
                }

                this.mortgagePeriod = value;
            }
        }

        public void Deposit(decimal moneyToDeposit)
        {
            if (moneyToDeposit <= 0M)
            {
                throw new ArgumentOutOfRangeException("Can't deposit zero or negative amount of money!");
            }

            this.Balance += moneyToDeposit;
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Customer == CustomerType.Company && this.MortgagePeriod <= 12)
            {
                return (this.MortgagePeriod * this.InterestRate) / 2M;
            }
            else if (this.Customer == CustomerType.Individual && this.MortgagePeriod <= 6)
            {
                return 0M;
            }

            return (this.MortgagePeriod * this.InterestRate);
        }
    }
}
