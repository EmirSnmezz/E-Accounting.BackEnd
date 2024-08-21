using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF
{
    public class CreateUCAFRequest : IRequest<CreateUCAFResponse>
    {
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }
        public string Code { get; set; }
    }   
}
