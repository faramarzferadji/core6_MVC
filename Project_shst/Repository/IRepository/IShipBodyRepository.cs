using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IShipBodyRepository : IRepository<ShipBody>
    {
        void Update(ShipBody obj);
        void Save();
    }
}
