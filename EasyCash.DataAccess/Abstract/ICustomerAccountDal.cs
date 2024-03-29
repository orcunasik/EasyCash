﻿using EasyCash.Entities.Concrete;

namespace EasyCash.DataAccess.Abstract;

public interface ICustomerAccountDal : IEntityRepositoryDal<CustomerAccount>
{
    List<CustomerAccount> GetCustomerAccountList(int id);
}
