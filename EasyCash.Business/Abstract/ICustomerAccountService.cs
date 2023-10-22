using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Abstract;

public interface ICustomerAccountService : IBaseService<CustomerAccount>
{
    List<CustomerAccount> GetCustomerAccountList(int id);
}
