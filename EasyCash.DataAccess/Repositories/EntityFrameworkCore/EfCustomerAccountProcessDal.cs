using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.DataAccess.Repositories.EntityFrameworkCore;

public class EfCustomerAccountProcessDal : EfEntityRepositoryDal<CustomerAccountProcess>, ICustomerAccountProcessDal
{
    public List<CustomerAccountProcess> MyLastProcess(int id)
    {
        using (var context = new EasyCashDbContext())
        {
            var datas = context.CustomerAccountProcesses.Include(i => i.SenderCustomer).ThenInclude(x => x.AppUser).Where(c => c.ReceiverId == id || c.SenderId == id).ToList();
            return datas;
        }
    }
}
