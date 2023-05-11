using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class AniversarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
