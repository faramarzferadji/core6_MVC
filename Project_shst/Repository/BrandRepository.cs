using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private ApplicationDbContext _db;
        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Brand obj)
        {
            _db.BrandAffer.Update(obj);
        }
    }
}
