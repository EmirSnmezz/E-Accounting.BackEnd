using E_Accounted_BackEnd.Presentation.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class UserAndCompanyRelationShipsController : ApiController
    {
        public UserAndCompanyRelationShipsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
