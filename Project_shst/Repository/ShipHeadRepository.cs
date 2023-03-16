using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class ShipHeadRepository : Repository<ShipHead>, IShipHeadRepository
    {
        private ApplicationDbContext _db;
        public ShipHeadRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ShipHead obj)
        {
            _db.Update(obj);
        }
    }
}
