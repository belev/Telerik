namespace Exam.WebApi.Models
{
    using Exam.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameModelDetailedInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public IEnumerable<GuessModel> YourGuesses { get; set; }

        public IEnumerable<GuessModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }
        
        public string GameState { get; set; }
    }
}