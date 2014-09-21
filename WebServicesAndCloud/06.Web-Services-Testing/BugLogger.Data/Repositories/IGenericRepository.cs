namespace BugLogger.Data.Repositories
{
    using System.Linq;

    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> All();

        T Add(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        void Detach(T entity);
        
        void SaveChanges();
    }
}