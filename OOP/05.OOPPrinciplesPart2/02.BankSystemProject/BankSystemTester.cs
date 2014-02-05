using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystemProject
{
    //2. A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
    //Customers could be individuals or companies.
    //All accounts have customer, balance and interest rate (monthly based). 
    //Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
    //All accounts can calculate their interest amount for a given period (in months).
    //In the common case its is calculated as follows: number_of_months * interest_rate.
    //Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
    //Deposit accounts have no interest if their balance is positive and less than 1000.
    //Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
    //Your task is to write a program to model the bank system by classes and interfaces. 
    //You should identify the classes, interfaces, base classes and abstract actions and 
    //implement the calculation of the interest functionality through overridden methods
    class BankSystemTester
    {
        static void Main()
        {
            Account[] accounts = new Account[]
            {
                new DepositAccount(CustomerType.Individual, 1000M, 4M, 12),
                new DepositAccount(CustomerType.Company, 10000M, 10M, 24),

                new LoanAccount(CustomerType.Company, 5000M, 1.5M, 10),
                new LoanAccount(CustomerType.Individual, 560M, 2M, 4),

                new MortgageAccount(CustomerType.Individual, 6500M, 6M, 14),
                new MortgageAccount(CustomerType.Individual, 1300M, 4.2M, 11)
            };

            foreach (Account account in accounts)
            {
                Console.WriteLine("{0} interest amount -> {1}", account.GetType().Name, account.CalculateInterestAmount());
            }

            DepositAccount depositAccount = new DepositAccount(CustomerType.Individual, 1000M, 3M, 6);
            depositAccount.Deposit(1000M);
            depositAccount.WithDraw(1900M);

            Console.WriteLine(depositAccount.Balance);

            LoanAccount loanAccount = new LoanAccount(CustomerType.Company, 1500M, 5M, 10);
            loanAccount.Deposit(440.5M);

            Console.WriteLine(loanAccount.Balance);

            MortgageAccount mortgageAccount = new MortgageAccount(CustomerType.Individual, 100M, 1M, 1);
            mortgageAccount.Deposit(5000M);

            Console.WriteLine(mortgageAccount.Balance);
        }
    }
}
