using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IPaymentUserRepository:IRepository<PaymentUser>
    {
        void Update(Payment obj);
        void Save();
    }
}
