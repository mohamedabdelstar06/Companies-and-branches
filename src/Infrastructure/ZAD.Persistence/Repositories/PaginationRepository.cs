using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ZAD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ZAD.Persistence.Repositories
{
    public abstract class PaginationRepository<TEntity> : IPaginationRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly IMapper _mapper;

        protected PaginationRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, 
            int pageSize, 
            string? searchTerm, 
            string? sortColumn, 
            string? sortDirection, 
            bool? isActive);

        protected async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageInternalAsync<TResult>(
            IQueryable<TEntity> query,
            int pageIndex,
            int pageSize,
            string? sortColumn,
            string? sortDirection)
        {
            var totalCount = await query.CountAsync();

            if (!string.IsNullOrEmpty(sortColumn))
            {
                bool isDescending = sortDirection?.ToLower() == "desc";
                query = OrderByDynamic(query, sortColumn, isDescending);
            }

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return (items, totalCount);
        }

        private IQueryable<TEntity> OrderByDynamic(IQueryable<TEntity> query, string sortColumn, bool isDescending)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var property = Expression.Property(parameter, sortColumn);
            var lambda = Expression.Lambda(property, parameter);

            var method = isDescending ? "OrderByDescending" : "OrderBy";
            
            var resultExpression = Expression.Call(typeof(Queryable), method, 
                new Type[] { query.ElementType, property.Type },
                query.Expression, Expression.Quote(lambda));
                
            return query.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
