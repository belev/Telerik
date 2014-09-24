namespace Exam.WebApi.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;

    public class GameModelShortInfo
    {
        private const string NO_BLUE_PLAYER_YET = "No blue player yet";

        public static Expression<Func<Game, GameModelShortInfo>> FromGame
        {
            get
            {
                return g => new GameModelShortInfo
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

        public static GameModelShortInfo CreateGameModelShortInfo(Game game)
        {
            return new GameModelShortInfo
            {
                Id = game.GameId,
                Name = game.Name,
                Blue = NO_BLUE_PLAYER_YET,
                Red = game.RedPlayer.UserName,
                GameState = game.State.ToString(),
                DateCreated = game.CreatedOn
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}