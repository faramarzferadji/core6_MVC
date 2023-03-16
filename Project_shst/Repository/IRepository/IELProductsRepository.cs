using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IELProductsRepository : IRepository<ELProducts>
    {
        void Update(ELProducts obj);
        void Save();


    }
}
