using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystemProject
{
    public class LoanAccount : Account, IDepositable
    {
        private int loanPeriod;
        public LoanAccount(CustomerType customer, decimal balance, decimal interestRate, int loanPeriod)
            : base(customer, balance, interestRate)
        {
            this.LoanPeriod = loanPeriod;
        }

        public int LoanPeriod
        {
            get { return this.loanPeriod; }
            private set
            {
                if (value <= 0M)
                {
                    throw new ArgumentOutOfRangeException("Loan period can't be zero or negative!");
                }

                this.loanPeriod = value;
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
            if (this.Customer == CustomerType.Individual && this.LoanPeriod <= 3)
            {
                return 0M;
            }

            else if (this.Customer == CustomerType.Company && this.LoanPeriod <= 2)
            {
                return 0M;
            }

            return this.LoanPeriod * this.InterestRate;
        }
    }
}
