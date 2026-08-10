using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> AsQueryable();
        IQueryable<T> FindAllNoTracking();
        Task<IEnumerable<T>> FindAsync(Specification<T> specification);
        Task<T?> FirstOrDefaultAsync(Specification<T> specification);
        Task<System.Collections.Generic.IReadOnlyList<T>> GetAsync(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate);
    }
}
