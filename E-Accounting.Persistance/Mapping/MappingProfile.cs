using AutoMapper;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using E_Accounting.Domain.Entities.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<CreateUCAFCommand, UniformChartOfAccount>();
            CreateMap<CreateRoleCommand, AppRole>();
        }
    }
}
