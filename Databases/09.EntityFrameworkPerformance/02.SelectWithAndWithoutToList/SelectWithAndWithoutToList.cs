namespace _02.SelectWithAndWithoutToList
{
    using System;
    using System.Linq;
    using TelerikAcademy.Models;

    public class SelectWithAndWithoutToList
    {
        public static void Main()
        {
            var dbContext = new TelerikAcademyEntities();

            SelectWithToList(dbContext);
            SelectWithoutToList(dbContext);
        }

        private static void SelectWithToList(TelerikAcademyEntities dbContext)
        {
            using (dbContext)
            {
                var employessInSofia = dbContext.Employees
                                         .Select(e => e)
                                         .ToList()
                                         .Select(e => e.Address)
                                         .ToList()
                                         .Select(a => a.Town)
                                         .ToList()
                                         .Where(a => a.Name == "Sofia")
                                         .ToList();

                Console.WriteLine("Employees in Sofia count: " + employessInSofia.Count);
            }
        }

        private static void SelectWithoutToList(TelerikAcademyEntities dbContext)
        {
            using (dbContext)
            {
                var employessInSofia = dbContext.Employees
                                         .Select(e => e.Address)
                                         .Select(a => a.Town)
                                         .Where(a => a.Name == "Sofia")
                                         .ToList();

                Console.WriteLine("Employees in Sofia count: " + employessInSofia.Count);
            }
        }
    }
}