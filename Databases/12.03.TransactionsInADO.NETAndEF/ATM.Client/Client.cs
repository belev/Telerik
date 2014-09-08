namespace ATM.Client
{
    using System;
    using System.Linq;
    using ATM.Data;
    using ATM.Models;
    using System.Transactions;

    internal class Client
    {
        static void Main()
        {
            var atmContext = new AtmContext();
            atmContext.Database.Initialize(true);

            PrintAllCards();

            using (atmContext)
            {
                // for invalid data try with different pin, cardNumber and moneyToWithdraw to use that nothing happens
                int pin = 1111;
                int cardNumber = 1234567890;
                decimal moneyToWithdraw = 200M;

                if (WithdrawMoney(pin, cardNumber, moneyToWithdraw, atmContext))
                {
                    Console.WriteLine("\nMoney withdrawn\n");
                }
                else
                {
                    Console.WriteLine("\nCan not withdraw money.\n");
                }
            }

            PrintAllCards();
        }

        private static bool WithdrawMoney(int pin, int cardNumber, decimal moneyToWithdraw, AtmContext context)
        {
            var transactionScope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });

            using (transactionScope)
            {
                var card = context.CardAccounts.Where(c => c.CardNumber == cardNumber).FirstOrDefault();

                if (card == null)
                {
                    return false;
                }

                var isCardPinValid = card.CardPin == pin;
                var isMoneyToWithdrawValid = card.CardCash >= moneyToWithdraw;

                if (isCardPinValid && isMoneyToWithdrawValid)
                {
                    card.CardCash -= moneyToWithdraw;
                    transactionScope.Complete();
                }
                else
                {
                    return false;
                }
            }

            AddTransactionToHistory(cardNumber, moneyToWithdraw, context);
            context.SaveChanges();
            return true;
        }

        private static void AddTransactionToHistory(int cardNumber, decimal ammount, AtmContext context)
        {
            var transactionScope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });

            using (transactionScope)
            {
                context.TransactionHistories.Add(new TransactionHistory()
                {
                    TransactionDate = DateTime.Now,
                    Ammount = ammount,
                    CardNumber = cardNumber
                });

                transactionScope.Complete();
            }
        }

        private static void PrintAllCards()
        {
            using (var context = new AtmContext())
            {
                foreach (var card in context.CardAccounts)
                {
                    Console.WriteLine("ID:{0} -> Money: {1}", card.CardAccountId, card.CardCash);
                }
            }
        }
    }
}