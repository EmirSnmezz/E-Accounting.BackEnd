using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.DTOs;
    public sealed record RefreshTokenDto(string Token, string RefreshToken, DateTime RefreshTokenExperies);
 
