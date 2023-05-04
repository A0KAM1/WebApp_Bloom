using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class ListaConvidadosController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}
