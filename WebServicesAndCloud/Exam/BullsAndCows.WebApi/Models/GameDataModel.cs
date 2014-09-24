namespace Exam.WebApi.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;

    public class GameDataModel
    {
        private const string NO_BLUE_PLAYER_YET = "No blue player yet";
        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    Id = g.GameId,
                    Name = g.Name,
                    Blue = g.BluePlayer.UserName == null ? NO_BLUE_PLAYER_YET : g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = g.State.ToString(),
                    DateCreated = g.CreatedOn
                };
            }
        }

        public GameDataModel ModelToReturnAfterGameCreated()
        {
            return new GameDataModel()
            {
                Id = this.Id,
                Number = this.Number,
                Name = this.Name,
                Red = this.Red,
                Blue = NO_BLUE_PLAYER_YET,
                GameState = this.GameState.ToString(),
                DateCreated = this.DateCreated,
            };
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}