using DataLayer.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChurchManagementSystem.Jwt
{
    public static class JwtAuthHelper
    {
        public static void SetupApplicationJwtAuthentication(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            _ = serviceCollection
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   options.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = context =>
                       {
                           string authorization = context.Request.Headers[HeaderNames.Authorization];
                           if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                           {
                               context.Token = authorization.Substring("Bearer ".Length).Trim();
                           }
                           else if (context.Request.Cookies.Any(t => t.Key == "Bearer"))
                           {
                               var bearerToken = context.Request.Cookies.FirstOrDefault(t => t.Key == "Bearer");
                               context.Token = bearerToken.Value;
                           }

                           return Task.CompletedTask;
                       }
                   };

                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidIssuer = configuration["Auth:Jwt:Issuer"],
                       ValidAudience = configuration["Auth:Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:Key"]))
                   };
               });
        }

        public static string GenerateJwtToken(IConfiguration configuration, User user, IList<UserRole> userRoles = null, IList<UserClaims> userClaims = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //set base claims
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            if (userRoles != null)
            {
                //set roles
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            if (userClaims != null)
            {
                //set custom claims
                foreach (var claim in userClaims)
                {
                    claims.Add(new Claim(claim.Name, claim.Value));
                }
            }

            var token = new JwtSecurityToken(
                configuration["Auth:Jwt:Issuer"],
                configuration["Auth:Jwt:Audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddSeconds(Int32.Parse(configuration["Auth:Jwt:TokenDurationSeconds"])),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
