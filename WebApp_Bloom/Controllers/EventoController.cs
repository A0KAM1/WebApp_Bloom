using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult SelecionarEvento()
        {
            return View();
        }
        public IActionResult Casamento()
        {
            return View();
        }
        public IActionResult Aniversario()
        {
            return View();
        }
    }
}
