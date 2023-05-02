using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class ListaConvidados : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}
