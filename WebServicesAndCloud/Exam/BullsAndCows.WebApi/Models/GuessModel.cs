namespace Exam.WebApi.Models
{
    using System;
    using Exam.Models;

    public class GuessModel
    {
        public static Func<Guess, GuessModel> FromGuess
        {
            get
            {
                return g => new GuessModel
                {
                    Id = g.GuessId,
                    UserId = g.UserId,
                    Username = g.User.UserName,
                    GameId = g.GameId,
                    Number = g.Number,
                    DateMade = g.DateMade,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
