using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class ConvidadosController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}
