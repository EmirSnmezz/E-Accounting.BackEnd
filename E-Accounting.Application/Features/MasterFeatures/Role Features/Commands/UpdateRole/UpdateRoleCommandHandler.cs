﻿using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Commands.UpdateRole
{
    public sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleManager;
        public UpdateRoleCommandHandler(IRoleService roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleManager.GetByIdAsync(request.Id);

            if (role == null)
            {
                throw new Exception("İlgili Rol Kaydı Bulunamadı...");
            }

            if (role.Code != request.Code)
            {
                AppRole checkCode = await _roleManager.GetByUCAFCode(request.Code);
                if (checkCode != null)
                    throw new Exception("Bu Rol Daha Önce Kaydedilmiş!");
            }
            role.Name = request.Name;
            role.Code = request.Code;
            await _roleManager.UpdateAsync(role);

            return new UpdateRoleCommandResponse();
        }
    }
}
