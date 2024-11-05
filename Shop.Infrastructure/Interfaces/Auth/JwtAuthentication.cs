using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Interfaces.Auth;
using Shop.Domain.Dtos.User;
using Shop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shop.Infrastructure.Interfaces.Auth
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public JwtAuthentication(IConfiguration config, IHttpContextAccessor contextAccessor)
        {
            _config = config;
            _contextAccessor = contextAccessor;
        }

        public TokenResultDto GenerateToken(UserInfoDto userInfo)
        {
            string jwtToken = "";
            Guid refreshToken;

            //create cliams for store useritem data
            var claims = new List<Claim>
            {
                new Claim("Id",userInfo.Id.ToString()),
                new Claim("Phone",userInfo.PhoneNumber.ToString()),
                new Claim("Permissions",JsonConvert.SerializeObject(userInfo.Permissions))
            };

            string key = _config["Jwt:key"];
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenExpire = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:issuer"],
                audience: _config["Jwt:audience"],
                notBefore: DateTime.Now,
                expires: tokenExpire,
                claims: claims,
                signingCredentials: credential
                );

            try
            {
                //Generate token and refreshToken
                jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                refreshToken = Guid.NewGuid();
                return new TokenResultDto
                {
                    RefreshToken = refreshToken.ToString(),
                    ExpireDate = tokenExpire,
                    TokenID = jwtToken
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

        }

        public long GetCurrentUserId()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(_contextAccessor.HttpContext.Request.Headers["Authorization"]);
            var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            return long.Parse(claimValue);
        }

        public UserInfoDto ReadTokenClaims()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(_contextAccessor.HttpContext.Request.Headers["Authorization"]);
                return new UserInfoDto
                {
                    Id = GetCurrentUserId(),
                    Permissions = JsonConvert.DeserializeObject<List<Domain.Enums.Permission>>(securityToken.Claims.FirstOrDefault(c => c.Type == "Permissions")?.Value).ToList()
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool TokenIsValid(string token)
        {
            try
            {
                string key = _config["Jwt:key"];
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                SecurityToken securityToken;
                var jwtHandler = new JwtSecurityTokenHandler();

                jwtHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidAudience = _config["Jwt:audience"],
                    ValidIssuer = _config["Jwt:issuer"],
                },out securityToken);

                return true;
             }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
