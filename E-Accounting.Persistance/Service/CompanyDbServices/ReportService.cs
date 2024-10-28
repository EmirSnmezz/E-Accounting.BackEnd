using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.CompanyDbContext.ReportRepositories;
using E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using E_Accounting.Application.Services.CompanyServices;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.CompanyDbServices
{
    public sealed class ReportService : IReportService
    {
        private CompanyDbContext _context;
        private readonly IContextService _contextService;
        private readonly IReportCommandRepository _commandRepostiory;
        private readonly IReportQueryRepository _queryRepository;
        private readonly ICompanyUnitOfWork _unifOfWork;
        public ReportService(IContextService contextService, IReportCommandRepository commandRepository, IReportQueryRepository queryRepository, ICompanyUnitOfWork unitOfWork)
        {
            _contextService = contextService;
            _commandRepostiory = commandRepository;
            _queryRepository = queryRepository;
            _unifOfWork = unitOfWork;
        }
        public async Task<IList<Report>> GetAllReportsByCompanyId(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll(false).OrderByDescending(p => p.CreatedDate).ToListAsync();
        }

        public async Task Request(RequestReportCommand request,CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepostiory.SetDbContextInstance(_context);
            _unifOfWork.SetDbContextInstance(_context);

            Report report = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Status = false,
            };

            await _commandRepostiory.AddAsync(report, cancellationToken);
            await _unifOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
