using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using System.Linq.Expressions;

namespace EasyCash.DataAccess.Repositories
{
    public class EfEntityRepositoryDal<TEntity> : IEntityRepositoryDal<TEntity> where TEntity : class, new()
    {
        public void Delete(TEntity entity)
        {
            using EasyCashDbContext context = new EasyCashDbContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            using EasyCashDbContext context = new EasyCashDbContext();
            return context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using EasyCashDbContext context = new EasyCashDbContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Insert(TEntity entity)
        {
            using EasyCashDbContext context = new EasyCashDbContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using EasyCashDbContext context = new EasyCashDbContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
