using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class ELProductsRepository : Repository<ELProducts>, IELProductsRepository
    {
        private ApplicationDbContext _db;
        public ELProductsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ELProducts obj)
        {
            _db.Update(obj);
        }
    }
}
