namespace _01.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Salaries
    {
        private static IDictionary<int, long> employeesSalaries;
        private static IDictionary<int, List<int>> employees = new Dictionary<int, List<int>>();

        static void Main()
        {
            ReadInput();

            long salariesSum = 0;

            foreach (var emp in employees)
            {
                salariesSum += FindEmployeeSalary(emp);
            }

            Console.WriteLine(salariesSum);
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            employeesSalaries = new Dictionary<int, long>(
                Enumerable.Range(0, n).Select(i => new { Key = i + 1, Value = 0L })
                .ToDictionary(x => x.Key, x => x.Value)
                );

            employees = new Dictionary<int, List<int>>(
                Enumerable.Range(0, n).Select(i => new { Key = i + 1, Value = new List<int>() })
                .ToDictionary(x => x.Key, x => x.Value)
                );

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        employees[i + 1].Add(j + 1);
                    }
                }
            }
        }

        private static long FindEmployeeSalary(KeyValuePair<int, List<int>> employee)
        {
            var employeeSalary = employeesSalaries[employee.Key];

            if (employeeSalary != 0)
            {
                return employeeSalary;
            }

            if (employee.Value.Count == 0)
            {
                employeesSalaries[employee.Key] = 1;
                return 1;
            }

            foreach (var item in employee.Value)
            {
                employeeSalary += FindEmployeeSalary(new KeyValuePair<int, List<int>>(item, employees[item]));
            }

            employeesSalaries[employee.Key] = employeeSalary;

            return employeeSalary;
        }
    }
}