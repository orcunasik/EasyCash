using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Abstract
{
    public interface ICustomerAccountProcessService : IBaseService<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> MyLastProcess(int id);
    }
}
