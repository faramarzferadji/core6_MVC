using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IShipHeadRepository : IRepository<ShipHead>
    {
        void Update(ShipHead obj);
        void Save();
    }
}
