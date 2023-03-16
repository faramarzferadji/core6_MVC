using System.Linq.Expressions;

namespace Project_shst.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstorDefult(Expression<Func<T, bool>> Filter, string? includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
