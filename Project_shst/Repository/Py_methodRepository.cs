using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class Py_methodRepository : Repository<Pyment_method>, IPy_methodRepository
    {
        private ApplicationDbContext _db;
        public Py_methodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

       

        public void Update(Pyment_method obj)
        {
            _db.Update(obj);
        }
    }
}
