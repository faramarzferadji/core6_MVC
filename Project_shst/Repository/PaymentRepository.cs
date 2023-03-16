using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class PaymentRepository : Repository<Payment>, IpaymentRepository
    {
        private ApplicationDbContext _db;
        public PaymentRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Payment obj)
        {
            _db.Update(obj);
        }
    }
}
