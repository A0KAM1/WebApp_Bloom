using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
