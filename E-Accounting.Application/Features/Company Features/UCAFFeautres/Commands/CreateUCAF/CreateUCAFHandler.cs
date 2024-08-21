using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF
{
    public class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
    {
        public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
        {
            return new();
        }
    }
}
