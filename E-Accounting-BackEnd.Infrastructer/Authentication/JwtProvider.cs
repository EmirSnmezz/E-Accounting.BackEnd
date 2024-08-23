using E_Accounting.Application.Abstraction.JWT;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting_BackEnd.Infrastructer.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JWTOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtProvider(IOptions<JWTOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }
        public async Task<string> CreateTokenAsync(AppUser user, List<string> roles)
        {
            var claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserFirstAndLastName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Authentication, user.Id),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
                };

            DateTime expires = DateTime.Now.AddDays(1);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes
                (_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            user.RefreshToken =  refreshToken;
            user.RefreshTokenExpires = expires.AddDays(1);
            await _userManager.UpdateAsync(user);
            return token;
        }
    }
}
