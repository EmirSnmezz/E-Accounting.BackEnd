﻿using E_Accounting.Application.Messaging;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Queries.GetAllRoles
{
    public record GetAllRolesQuery() : IQuery<GetAllRolesQueryResponse>;
}
