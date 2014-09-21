namespace BugLogger.Data
{
    using System;
    using System.Collections.Generic;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;

    public class BugLoggerData : IBugLoggerData
    {
        private IBugLoggerDbContext context;
        private IDictionary<Type, object> repositories;

        public BugLoggerData()
            : this(new BugLoggerDbContext())
        {

        }

        public BugLoggerData(IBugLoggerDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>) this.repositories[typeOfModel];
        }
    }
}