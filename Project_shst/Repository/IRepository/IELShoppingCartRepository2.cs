using Project_shst.Models;

namespace Project_shst.Repository.IRepository
{
    public interface IELShoppingCartRepository2 : IRepository<ELShoppingCart2>
    {
        int DecrementCount(ELShoppingCart2 eLShoppingCart, int count);
        int IncrementCount(ELShoppingCart2 eLShoppingCart, int count);
    }
}
