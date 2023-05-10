using System.Linq.Expressions;

namespace EasyCash.DataAccess.Abstract
{
    public interface IEntityRepositoryDal<T> where T : class,new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IList<T> GetList(Expression<Func<T,bool>> filter = null);
    }
}
