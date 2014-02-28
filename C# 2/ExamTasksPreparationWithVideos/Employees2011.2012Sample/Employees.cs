using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employess_Live
{
    class Employee
    {
        public int MyProperty { get; set; }
        public string FirstName { get; set; }

        public string LastName
        {
            get;
            set;
        }

        public int Rank
        {
            get;
            set;
        }

        public string Position
        {
            get;
            set;
        }
    }

    public class Program
    {
        internal static void Main()
        {
            Dictionary<string, int> posAndRank = new Dictionary<string, int>();

            int numberOfPos = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPos; i++)
            {
                string line = Console.ReadLine();

                string[] rawInput = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (!posAndRank.ContainsKey(rawInput[0]))
                {
                    posAndRank.Add(rawInput[0], int.Parse(rawInput[1]));
                }
            }

            int numberOfWorkers = int.Parse(Console.ReadLine());

            List<Employee> allWorkers = new List<Employee>();

            for (int i = 0; i < numberOfWorkers; i++)
            {
                string line = Console.ReadLine();
                string[] rawInput = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                Employee currentEmp = new Employee();
                string[] spliteName = rawInput[0].Split();
                currentEmp.FirstName = spliteName[0];
                currentEmp.LastName = spliteName[1];
                currentEmp.Position = rawInput[1];
                currentEmp.Rank = posAndRank[currentEmp.Position];

                allWorkers.Add(currentEmp);
            }

            var sortedWorkers = allWorkers
                .OrderByDescending(em => em.Rank)
                .ThenBy(em => em.LastName)
                .ThenBy(em => em.FirstName);

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} {1}", worker.FirstName, worker.LastName);
            }
        }
    }
}
