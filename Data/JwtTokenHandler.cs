using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Employeemanagement.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Employeemanagement.Data
{

    public class JwtTokenHandler
    {

        private JwtSettings jwtSettings;

        public JwtTokenHandler(IOptions<JwtSettings> options)
        {
               this.jwtSettings = options.Value;
        }
        public string GeneratJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Name),new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.Now.AddSeconds(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokendescriptor);
            string finaltoken = tokenHandler.WriteToken(token);
            return finaltoken;
        }
    }
}