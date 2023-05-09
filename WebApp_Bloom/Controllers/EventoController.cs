using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult SelecionarEvento()
        {
            return View();
        }
    }
}
