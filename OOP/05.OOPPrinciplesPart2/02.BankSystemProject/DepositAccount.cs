using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystemProject
{
    public class DepositAccount : Account, IDepositable, IWithDrawable
    {
        private int depositPeriod;

        public DepositAccount(CustomerType customer, decimal balance, decimal interestRate, int depositPeriod)
            : base(customer, balance, interestRate)
        {
            this.DepositPeriod = depositPeriod;
        }

        public int DepositPeriod 
        {
            get { return this.depositPeriod; }
            private set
            {
                if (value <= 0M)
                {
                    throw new ArgumentOutOfRangeException("Deposit period can't be zero or negative!");
                }

                this.depositPeriod = value;
            }
        }
        public override decimal CalculateInterestAmount()
        {
            if (this.Balance > 0M && this.Balance < 1000M)
            {
                return 0M;
            }
            else
            {
                return (this.InterestRate * this.DepositPeriod);
            }
        }

        public void Deposit(decimal moneyToDeposit)
        {
            if (moneyToDeposit <= 0M)
            {
                throw new ArgumentOutOfRangeException("Can't deposit negative amount of money!");
            }

            this.Balance += moneyToDeposit;
        }

        public void WithDraw(decimal moneyToWithDraw)
        {
            if (moneyToWithDraw <= 0M)
            {
                throw new ArgumentOutOfRangeException("Can't with draw negative amount of money!");
            }

            if (this.Balance < moneyToWithDraw)
            {
                throw new ArgumentOutOfRangeException("Can't withdraw more money than have in balance!");
            }

            this.Balance -= moneyToWithDraw;
        }
    }
}
