namespace BullsAndCows.Wcf.Models
{
    using Exam.Models;
    using System;
    using System.Linq.Expressions;

    public class UserShortInfoModel
    {
        public static Expression<Func<User, UserShortInfoModel>> FromUser
        {
            get
            {
                return u => new UserShortInfoModel
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }
}