namespace ATM.Models
{
    using System;
    using System.Linq;

    public class CardAccount
    {
        public int CardAccountId { get; set; }

        public int CardNumber { get; set; }

        public int CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
