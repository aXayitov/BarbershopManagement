using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
