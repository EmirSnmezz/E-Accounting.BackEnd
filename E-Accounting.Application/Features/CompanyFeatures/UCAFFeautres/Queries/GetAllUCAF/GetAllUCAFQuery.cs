using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetAllUCAF;
    public record GetAllUCAFQuery
    (
        string companyId
        ) : IQuery<GetAllUCAFQueryResponse>;

