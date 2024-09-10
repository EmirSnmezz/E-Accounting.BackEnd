using E_Accounted_BackEnd.Presentation.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    class MainRoleAndUserRelationShipsController : ApiController
    {
        public MainRoleAndUserRelationShipsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
