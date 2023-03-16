using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _db;
        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Brand = new BrandRepository(_db);
            ELProducts = new ELProductsRepository(_db);
        
            ELShoppingCart2 = new ELShoppingCartRepository2(_db);
            applicationUser = new ApplicationUserRepository(_db);
            shipBody = new ShipBodyRepository(_db);
            shipHead = new ShipHeadRepository(_db);
            py_method= new Py_methodRepository(_db);
            payment=new PaymentRepository(_db);
            paymentUser=new PaymentUserRepository(_db);
        }
        public IBrandRepository Brand { get; private set; }
        public IELProductsRepository ELProducts { get; private set; }
       
        public IELShoppingCartRepository2 ELShoppingCart2 { get; private set; }

        public IApplicationUser applicationUser { get; private set; }
        public IShipBodyRepository shipBody { get; private set; }
        public IShipHeadRepository shipHead { get; private set; }
        public IPy_methodRepository py_method { get; private set; }
        public IpaymentRepository payment { get; private set; }
        public IPaymentUserRepository paymentUser { get; private set; }
















        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
