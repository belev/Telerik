namespace _01.SelectWithAndWithoutInclude
{
    using System;
    using System.Linq;
    using TelerikAcademy.Models;

    public class SelectWithAndWithoutInclude
    {
        public static void Main()
        {
            var dbContext = new TelerikAcademyEntities();

            SelectEmployessWithoutInclude(dbContext);
            SelectEmployessWithInclude(dbContext);
        }

        private static void SelectEmployessWithoutInclude(TelerikAcademyEntities dbContext)
        {
            using (dbContext)
            {
                foreach (var employee in dbContext.Employees)
                {
                    var firstName = employee.FirstName;
                    var departmentName = employee.Department.Name;
                    var townName = employee.Address.Town.Name;

                    Console.WriteLine("{{ Name: {0}, Department: {1}, Town: {2} }}",
                        firstName, departmentName, townName);
                }
            }
        }

        private static void SelectEmployessWithInclude(TelerikAcademyEntities dbContext)
        {
            using (dbContext)
            {
                foreach (var employee in dbContext.Employees.Include("Department").Include("Address.Town"))
                {
                    var firstName = employee.FirstName;
                    var departmentName = employee.Department.Name;
                    var townName = employee.Address.Town.Name;

                    Console.WriteLine("{{ Name: {0}, Department: {1}, Town: {2} }}",
                        firstName, departmentName, townName);
                }
            }
        }
    }
}
