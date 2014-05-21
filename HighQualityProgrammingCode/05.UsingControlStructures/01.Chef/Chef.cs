namespace _01.Chef
{
    public class Chef
    {
        public static void Main(string[] args)
        {
        }

        public void Cook()
        {
            Carrot carrot = GetCarrot();
            Cut(carrot);
            Peel(carrot);

            Potato potato = GetPotato();
            Cut(potato);
            Peel(potato);

            Bowl bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            // ...
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            // ...
            return new Carrot();
        }

        private Potato GetPotato()
        {
            // ...
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            // ...
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }
    }
}