using System.Linq;
using System.Threading.Tasks;
using ZAD.Domain.Entities;

namespace ZAD.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> AsQueryable();
        IQueryable<T> FindAllNoTracking();
    }
}
