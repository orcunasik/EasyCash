using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Entities.Concrete;

namespace EasyCash.DataAccess.Repositories.EntityFrameworkCore;

public class EfCustomerAccountDal : EfEntityRepositoryDal<CustomerAccount>, ICustomerAccountDal
{
    public List<CustomerAccount> GetCustomerAccountList(int id)
    {
        using (EasyCashDbContext context = new())
        {
            var datas = context.CustomerAccounts.Where(c => c.AppUserId == id).ToList();
            return datas;
        }
    }
}
