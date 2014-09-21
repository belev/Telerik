namespace BugLogger.Services.Models
{
    using System;
    using BugLogger.Models;
    using System.Linq.Expressions;

    public class BugModel
    {
        public static Expression<Func<Bug, BugModel>> FromBug
        {
            get
            {
                return b => new BugModel
                {
                    BugId = b.BugId,
                    Text = b.Text,
                    Status = b.Status,
                    LogDate = b.LogDate
                };
            }
        }

        public int BugId { get; set; }

        public string Text { get; set; }

        public BugStatus Status { get; set; }

        public DateTime? LogDate { get; set; }
    }
}