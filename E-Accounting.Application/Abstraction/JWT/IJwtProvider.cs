using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.JWT
{
    public interface IJwtProvider
    {

        Task<string> CreateTokenAsync(AppUser user, List<string> roles );
    }
}
