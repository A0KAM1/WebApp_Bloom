using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult FAQ()
        {
            return View();
        }
    }
}
