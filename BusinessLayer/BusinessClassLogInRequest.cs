using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BusinessLayer
{
    public class BusinessClassLogInRequest : IBusinessClassLogInRequest
    {
        private readonly IRepoClassLogInRequest iRepoClassLogInRequest;
        public BusinessClassLogInRequest(IRepoClassLogInRequest iRepoClassLogInRequest)
        {
            this.iRepoClassLogInRequest = iRepoClassLogInRequest;
        }

        public string LogInRequest(string userEmail, string userPassword)
        {
            Employee result = iRepoClassLogInRequest.LogInRequest(userEmail, userPassword);
            if(result != null )
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, userEmail),
                    new Claim(ClaimTypes.Role, result.Position!)
                };

                var token = new JwtSecurityToken
                (
                    issuer: "http://localhost:5255/",
                    audience: "http://localhost:5255/",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(3),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("custom key authentication")),
                        SecurityAlgorithms.HmacSha256)
                );

                string loginToken = new JwtSecurityTokenHandler().WriteToken(token);
                return loginToken;
            }
            else
            {
                return "User not found";
            }
        }
    }
}