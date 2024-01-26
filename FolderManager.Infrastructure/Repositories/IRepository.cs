using FolderManagerApp.Models;
using System.Linq.Expressions;

namespace FolderManager.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T? GetById(int id);
        IEnumerable<T> All { get; }
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        void Delete(T entity);
    }
}
