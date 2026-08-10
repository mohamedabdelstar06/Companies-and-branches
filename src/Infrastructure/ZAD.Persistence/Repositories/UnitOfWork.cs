using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using ZAD.Domain.SeedWork;

namespace ZAD.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public ICompanyRepository Companies { get; }
        public IBranchRepository Branches { get; }
        public IGenericRepository<ZAD.Domain.Entities.Lookups.Lookup> Lookups { get; }

        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Companies = new CompanyRepository(_context, _mapper);
            Branches = new BranchRepository(_context, _mapper);
            Lookups = new GenericRepository<ZAD.Domain.Entities.Lookups.Lookup>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries<Entity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetCreatedAt(DateTime.UtcNow);
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.SetUpdatedAt(DateTime.UtcNow);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
