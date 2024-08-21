using AutoMapper;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Service.MasterService
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly MasterDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService(MasterDbContext context, IMapper mapper)
        {
            _context = context;  
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string companyName)
        {
            return await _context.Set<Company>().FirstOrDefaultAsync(x => x.Name == companyName);
        }

        public async Task MigrateCompanyDatabase()
        {
          var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
