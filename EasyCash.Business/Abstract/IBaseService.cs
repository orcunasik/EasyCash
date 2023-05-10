using System.Linq.Expressions;

namespace EasyCash.Business.Abstract
{
    public interface IBaseService<T> where T : class,new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IList<T> GetList();
    }
}
