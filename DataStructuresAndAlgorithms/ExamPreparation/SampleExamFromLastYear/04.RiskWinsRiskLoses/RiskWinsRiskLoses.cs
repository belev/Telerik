namespace _04.RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class RiskWinsRiskLoses
    {
        private static string initialConfiguration;
        private static string targetConfiguration;
        private static HashSet<string> forbiddenConfigurations;

        private static void Main()
        {
            ReadInput();

            FindMinimumButtonClicksCount();
        }

        private static void ReadInput()
        {
            initialConfiguration = Console.ReadLine();
            targetConfiguration = Console.ReadLine();
            forbiddenConfigurations = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                forbiddenConfigurations.Add(Console.ReadLine());
            }
        }

        private static void FindMinimumButtonClicksCount()
        {
            var configurations = new Queue<Tuple<string, int>>();
            configurations.Enqueue(new Tuple<string, int>(initialConfiguration, 0));

            forbiddenConfigurations.Add(initialConfiguration);

            while (configurations.Count != 0)
            {
                var currentConfiguration = configurations.Dequeue();

                if (currentConfiguration.Item1 == targetConfiguration)
                {
                    Console.WriteLine(currentConfiguration.Item2);
                    return;
                }

                var nextConfiguration = new StringBuilder(currentConfiguration.Item1);
                var previousConfiguration = new StringBuilder(currentConfiguration.Item1);

                for (int i = 0; i < 5; i++)
                {
                    var digit = currentConfiguration.Item1[i] - '0';

                    var nextDigit = (digit + 1) % 10;
                    var previousDigit = (digit - 1) < 0 ? 9 : (digit - 1);

                    nextConfiguration[i] = (char)(nextDigit + '0');
                    previousConfiguration[i] = (char)(previousDigit + '0');

                    if (!forbiddenConfigurations.Contains(nextConfiguration.ToString()))
                    {
                        forbiddenConfigurations.Add(nextConfiguration.ToString());
                        configurations.Enqueue(new Tuple<string, int>(nextConfiguration.ToString(), currentConfiguration.Item2 + 1));
                    }

                    if (!forbiddenConfigurations.Contains(previousConfiguration.ToString()))
                    {
                        forbiddenConfigurations.Add(previousConfiguration.ToString());
                        configurations.Enqueue(new Tuple<string, int>(previousConfiguration.ToString(), currentConfiguration.Item2 + 1));
                    }

                    nextConfiguration[i] = currentConfiguration.Item1[i];
                    previousConfiguration[i] = currentConfiguration.Item1[i];
                }
            }

            Console.WriteLine(-1);
        }
    }
}
