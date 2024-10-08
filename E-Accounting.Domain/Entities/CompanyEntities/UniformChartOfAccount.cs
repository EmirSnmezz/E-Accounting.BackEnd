﻿using E_Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Entities.CompanyEntities
{
    public sealed class UniformChartOfAccount : BaseEntity
    {
        public UniformChartOfAccount()
        {
            
        }

        public UniformChartOfAccount(string id, string name, string code, string type) : base(id)
        {
            Name = name;
            Code = code;
            Type = type;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
