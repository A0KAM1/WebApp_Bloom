using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class ConvidadosController : Controller
    {
        
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Editar( ConvidadosEntidade convidado) {

            if (convidado != null)
            {
                return View(convidado);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
    }
}
