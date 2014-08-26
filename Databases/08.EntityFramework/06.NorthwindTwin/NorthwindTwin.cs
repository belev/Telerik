namespace _06.NorthwindTwin
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using Northwind.Models;

    public class NorthwindTwin
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new NorthwindEntities())
            {
                string generatedScript = ((IObjectContextAdapter) dbContext).ObjectContext.CreateDatabaseScript();

                StringBuilder dbScript = new StringBuilder();
                dbScript.Append("USE NorthwindTwin ");
                dbScript.Append(generatedScript);

                dbContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "CREATE DATABASE NorthwindTwin");
                dbContext.Database.ExecuteSqlCommand(dbScript.ToString());
            }
        }
    }
}