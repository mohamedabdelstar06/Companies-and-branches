using System;
using System.Threading.Tasks;
using AutoMapper;
using ZAD.Domain.Entities;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ZAD.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        private ICompanyRepository? _companies;
        private IBranchRepository? _branches;

        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICompanyRepository Companies => _companies ??= new CompanyRepository(_context, _mapper);
        public IBranchRepository Branches => _branches ??= new BranchRepository(_context, _mapper);

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}
