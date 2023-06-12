using EasyCash.DataAccess.Abstract;
using EasyCash.Entities.Concrete;

namespace EasyCash.DataAccess.Repositories.EntityFrameworkCore
{
    public class EfCustomerAccountProcessDal : EfEntityRepositoryDal<CustomerAccountProcess>,ICustomerAccountProcessDal
    {
    }
}
