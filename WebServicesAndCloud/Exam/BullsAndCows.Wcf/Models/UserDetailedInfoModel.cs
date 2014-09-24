namespace BullsAndCows.Wcf.Models
{
    using Exam.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserDetailedInfoModel
    {
        private const int WINS_COUNT_MULTIPLIER = 100;
        private const int LOOSES_COUNT_MULTIPLIER = 100;

        public static Expression<Func<User, UserDetailedInfoModel>> FromUser
        {
            get
            {
                return u => new UserDetailedInfoModel
                {
                    UserId = u.Id,
                    Username = u.UserName,
                    WinsCount = u.WinsCount,
                    LoosesCount = u.LoosesCount,
                    Rank = u.WinsCount * WINS_COUNT_MULTIPLIER + u.LoosesCount * LOOSES_COUNT_MULTIPLIER
                };
            }
        }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int WinsCount { get; set; }

        [DataMember]
        public int LoosesCount { get; set; }

        [DataMember]
        public int Rank { get; set; }
    }
}
