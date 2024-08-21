using AutoMapper;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Domain.Entities.App_Entites;
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
            CreateMap<CreateCompanyRequest, Company>().ReverseMap(); // ?
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
        }
    }
}
