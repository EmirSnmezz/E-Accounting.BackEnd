using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
namespace E_Accounting.Persistance.UnitOfWorkds
{
    public sealed class MasterDbUnitOfWork : IMasterUnitOfWork
    {
        private MasterDbContext _masterDbContext;

        public MasterDbUnitOfWork(MasterDbContext context)
        {
            _masterDbContext = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            int count = await _masterDbContext.SaveChangesAsync(cancellationToken);
            return count;
        }


    }
}
