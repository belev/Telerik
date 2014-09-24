namespace Exam.Data
{
    using Exam.Models;
    using System;
    using System.Collections.Generic;

    public class BullsAndCowsData : IBullsAndCowsData
    {
        private IBullsAndCowsContext context;
        private IDictionary<Type, object> repositories;

        public BullsAndCowsData()
            : this(new BullsAndCowsContext())
        {

        }

        public BullsAndCowsData(IBullsAndCowsContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Guess> Guesses
        {
            get
            {
                return this.GetRepository<Guess>();
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