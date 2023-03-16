using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Repository
{
    public class ELShoppingCartRepository2 : Repository<ELShoppingCart2>, IELShoppingCartRepository2
    {
        private ApplicationDbContext _db;

        public ELShoppingCartRepository2(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ELShoppingCart2 eLShoppingCart, int count)
        {
            eLShoppingCart.Count -= count;
            return count;
        }

        public int IncrementCount(ELShoppingCart2 eLShoppingCart, int count)
        {
            eLShoppingCart.Count += count;
            return count;
        }


    }
}
