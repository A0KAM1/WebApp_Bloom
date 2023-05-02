using Microsoft.AspNetCore.Mvc;

namespace WebApp_Bloom.Controllers
{
    public class ListaConvidados : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
