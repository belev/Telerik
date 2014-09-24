namespace Exam.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Game
    {
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        public DateTime CreatedOn { get; set; }

        public GameState State { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        public virtual User RedPlayer { get; set; }

        public string BluePlayerId { get; set; }

        public virtual User BluePlayer { get; set; }
    }
}