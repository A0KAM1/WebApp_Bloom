using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
