using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            
        }

        public BaseEntity(string id)
        {
            Id = id;
        }

        public  string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
