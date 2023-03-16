using Project_shst.Areas.Identity.Data;

namespace Project_shst.Repository.IRepository
{
    public interface IUnitofWork
    {
        IBrandRepository Brand { get; }
        IELProductsRepository ELProducts { get; }
       
        IELShoppingCartRepository2 ELShoppingCart2 { get; }
        IApplicationUser applicationUser { get; }
        IShipBodyRepository shipBody { get; }
        IShipHeadRepository shipHead { get; }
        IPy_methodRepository py_method { get; }
        IpaymentRepository payment { get; }
        IPaymentUserRepository paymentUser { get; }

        void Save();
    } 
}
