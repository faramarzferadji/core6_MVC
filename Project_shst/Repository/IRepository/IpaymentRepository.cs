using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IpaymentRepository:IRepository<Payment>
    {
        void Update(Payment obj);
        void Save();
    }
}
