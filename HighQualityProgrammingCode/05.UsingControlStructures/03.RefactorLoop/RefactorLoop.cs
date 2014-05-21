namespace _03.RefactorLoop
{
    using System;

    public class RefactorLoop
    {
        public static void Main()
        {
            var array = new int[100];
            int expectedValue = int.MaxValue;

            bool isFound = false;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        isFound = true;
                        break;
                    }
                }
            }

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
