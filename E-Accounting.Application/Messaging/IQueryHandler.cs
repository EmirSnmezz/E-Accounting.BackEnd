﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Messaging
{
    public interface IQueryHandler<in TQuery , TResponse> : IRequestHandler<TQuery, TResponse>  
        where TQuery : IQuery<TResponse>
    {
    }
}
