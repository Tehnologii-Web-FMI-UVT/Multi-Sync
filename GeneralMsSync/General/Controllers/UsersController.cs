using DataLayer.Models;
using DataLayer.Repositiory;
using DataLayer.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChurchManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly IConfiguration mConfiguration;
        private readonly IPeopleRepository mPeopleRepository;
        private readonly ILogger<AuthController> mLogger;

        public UsersController(IConfiguration configuration, IPeopleRepository peopleRepository, ILogger<AuthController> logger)
        {
            mConfiguration = configuration;
            mPeopleRepository = peopleRepository;
            mLogger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
