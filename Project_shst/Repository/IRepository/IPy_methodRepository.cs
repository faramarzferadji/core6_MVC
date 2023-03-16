using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IPy_methodRepository : IRepository<Pyment_method>
    {
        void Update(Pyment_method obj);
        void Save();
    }
}
