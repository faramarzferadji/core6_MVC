using Microsoft.EntityFrameworkCore;
using Project_shst.Areas.Identity.Data;
using Project_shst.Repository.IRepository;
using System.Linq.Expressions;
using System.Linq;

namespace Project_shst.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.AutoShopAffer.Include(u => u.Auto).Include(u => u.ListFacture);

            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefult(Expression<Func<T, bool>>? Filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(Filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
