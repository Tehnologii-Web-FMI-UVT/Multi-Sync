using DataLayer.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DataLayer.Models;
using ChurchManagementSystem.Jwt;
using CMSShared;

namespace ChurchManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration mConfiguration;
        private readonly IUsersRepository mUsersRepository;
        private readonly IUserRolesRepository mUserRolesRepository;
        private readonly ILogger<AuthController> mLogger;

        public AuthController(IConfiguration configuration, IUsersRepository usersRepository, IUserRolesRepository userRolesRepository, ILogger<AuthController> logger)
        {
            mConfiguration = configuration;
            mUsersRepository = usersRepository;
            mUserRolesRepository = userRolesRepository;
            mLogger = logger;
        }

        public IActionResult AuthAdmin()
        {
            var token = JwtAuthHelper.GenerateJwtToken(mConfiguration, new DataLayer.Models.User()
            {
                Email = "test@mail.com",
                Id = 55,
                UserName = "username"
            }, new[] { new UserRole() { Id = 1, Name = "Admin" } });

            return Ok(token);
        }

        public IActionResult AuthAdminCookie()
        {
            var token = JwtAuthHelper.GenerateJwtToken(mConfiguration, new DataLayer.Models.User()
            {
                Email = "test@mail.com",
                Id = 55,
                UserName = "username"
            }, new[] { new UserRole() { Id = 1, Name = "Admin2" } });

            //Set Bearer as cookie
            HttpContext.Response.Cookies.Append("Bearer", token, new CookieOptions()
            {
                IsEssential = true,
                Expires = DateTime.Now.AddSeconds(30)
            });

            return Ok(token);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Login()
        {
            return Ok("asd");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string emailOrUsername, string password)
        {
            try
            {
                var authResult = await mUsersRepository.Authenticate(emailOrUsername, password);
                if (EResultStatus.Success != authResult.status)
                {
                    return Json(new Result
                    {
                        Status = authResult.status,
                        Message = authResult.message
                    });
                }

                var userRoles = await mUserRolesRepository.GetAllRolesForUser(authResult.user.Id);

                var jwtToken = JwtAuthHelper.GenerateJwtToken(mConfiguration, authResult.user, userRoles);
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    return Json(new Result
                    {
                        Status = EResultStatus.Success,
                        Message = jwtToken
                    });
                }
            }
            catch (Exception ex)
            {
                mLogger.LogError(ex, ex.Message);
            }

            return Json(new Result
            {
                Status = EResultStatus.Error,
                Message = "An error occurrend, please contact support if this persists!"
            });
        }
    }
}
