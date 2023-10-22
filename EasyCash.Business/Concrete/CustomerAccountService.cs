using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Abstract;
using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Concrete;

public class CustomerAccountService : ICustomerAccountService
{
    private readonly ICustomerAccountDal customerAccountDal;

    public CustomerAccountService(ICustomerAccountDal customerAccountDal)
    {
        this.customerAccountDal = customerAccountDal;
    }

    public void Delete(CustomerAccount entity)
    {
        customerAccountDal.Delete(entity);
    }

    public CustomerAccount GetById(int id)
    {
        return customerAccountDal.GetById(id);
    }

    public List<CustomerAccount> GetCustomerAccountList(int id)
    {
        return customerAccountDal.GetCustomerAccountList(id);
    }

    public IList<CustomerAccount> GetList()
    {
        return customerAccountDal.GetList();
    }

    public void Insert(CustomerAccount entity)
    {
        customerAccountDal.Insert(entity);
    }

    public void Update(CustomerAccount entity)
    {
        customerAccountDal.Update(entity);
    }
}
