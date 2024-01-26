using FolderManagerApp.Data;
using System.Linq.Expressions;

namespace FolderManager.Infrastructure.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected FolderManagerDbContext folderManagerDbContext;

        public GenericRepository(FolderManagerDbContext folderManagerDbContext)
        {
            this.folderManagerDbContext = folderManagerDbContext;
        }

        public virtual IEnumerable<T> All => folderManagerDbContext.Set<T>().ToList();

        public virtual T Add(T entity)
        {
            return folderManagerDbContext.Add(entity).Entity;
        }

        public virtual void Delete(T entity)
        {
            folderManagerDbContext.Remove(entity);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return folderManagerDbContext.Set<T>().AsQueryable().Where(predicate);
        }

        public virtual T? GetById(int id)
        {
            return folderManagerDbContext.Find<T>(id);
        }

        public virtual void SaveChanges()
        {
            folderManagerDbContext.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return folderManagerDbContext.Update(entity).Entity;
        }
    }
}
