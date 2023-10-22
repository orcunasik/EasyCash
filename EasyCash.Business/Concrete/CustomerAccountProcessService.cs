using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Abstract;
using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Concrete
{
    public class CustomerAccountProcessService : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal customerAccountProcessDal;

        public CustomerAccountProcessService(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            this.customerAccountProcessDal = customerAccountProcessDal;
        }

        public void Delete(CustomerAccountProcess entity)
        {
            customerAccountProcessDal.Delete(entity);
        }

        public CustomerAccountProcess GetById(int id)
        {
            return customerAccountProcessDal.GetById(id);
        }

        public IList<CustomerAccountProcess> GetList()
        {
            return customerAccountProcessDal.GetList();
        }

        public void Insert(CustomerAccountProcess entity)
        {
            customerAccountProcessDal.Insert(entity);
        }

        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            return customerAccountProcessDal.MyLastProcess(id);
        }

        public void Update(CustomerAccountProcess entity)
        {
            customerAccountProcessDal.Update(entity);
        }
    }
}
