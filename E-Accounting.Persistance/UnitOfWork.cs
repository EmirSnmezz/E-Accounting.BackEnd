using E_Accounting.Application;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private  CompanyDbContext _context;
        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
          int count = await _context.SaveChangesAsync(cancellationToken);
            return count;
        }
    }
}
