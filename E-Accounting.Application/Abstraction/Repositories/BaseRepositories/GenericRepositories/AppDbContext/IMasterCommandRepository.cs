﻿
using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext
{
    public interface IMasterCommandRepository <T> : ICommandGenericRepository<T>, IRepository<T> where T : BaseEntity
    {
    }
}
