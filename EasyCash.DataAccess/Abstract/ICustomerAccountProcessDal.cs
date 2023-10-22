using EasyCash.Entities.Concrete;

namespace EasyCash.DataAccess.Abstract
{
    public interface ICustomerAccountProcessDal : IEntityRepositoryDal<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> MyLastProcess(int id);
    }
}
