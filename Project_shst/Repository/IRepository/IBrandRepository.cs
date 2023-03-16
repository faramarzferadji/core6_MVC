using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        void Update(Brand obj);
        void Save();
    }
}
