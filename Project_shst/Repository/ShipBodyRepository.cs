using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class ShipBodyRepository : Repository<ShipBody>, IShipBodyRepository
    {
        private ApplicationDbContext _db;
        public ShipBodyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ShipBody obj)
        {
            _db.Update(obj);
        }
    }
}
