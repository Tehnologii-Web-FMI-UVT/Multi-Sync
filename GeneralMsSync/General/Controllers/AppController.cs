using Microsoft.AspNetCore.Mvc;

using RazorPartialToString.Services;

namespace ChurchManagementSystem.Controllers
{
    public class AppController : Controller
    {
        private readonly IRazorPartialToStringRenderer partialToStringRenderer;

        public AppController(IRazorPartialToStringRenderer partialToStringRenderer)
        {
            this.partialToStringRenderer = partialToStringRenderer;
        }

        public IActionResult Index()
        {
            ViewBag.partialToStringRenderer = partialToStringRenderer;

            return View();
        }
    }
}
