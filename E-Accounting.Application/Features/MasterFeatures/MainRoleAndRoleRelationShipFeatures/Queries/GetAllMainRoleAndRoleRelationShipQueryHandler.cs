using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Queries
{
    public sealed record GetAllMainRoleAndRoleRelationShipQueryHandler : IQueryHandler<GetAllMainRoleAndRoleRelationShipQuery, GetAllMainRoleAndRoleRelationShipQueryResponse>
    {
        private readonly IMainRoleAndRoleRelationShipService _service;

        public GetAllMainRoleAndRoleRelationShipQueryHandler(IMainRoleAndRoleRelationShipService service)
        {
            _service = service;
        }

        public async Task<GetAllMainRoleAndRoleRelationShipQueryResponse> Handle(GetAllMainRoleAndRoleRelationShipQuery request, CancellationToken cancellationToken)
        {
            return new(_service.GetAll().Include("AppRole").Include("MainRole").AsQueryable());
        }
    }
}
