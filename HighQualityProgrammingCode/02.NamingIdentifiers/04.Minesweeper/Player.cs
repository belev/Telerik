namespace Minesweeper
{
    public class Player
    {
        private string name;
        private int points;

        public Player()
        {
        }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
    }
}