using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Editar(FornecedorEntidade fornecedor ) {
            if (fornecedor != null)
            {
                return View(fornecedor);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
    }
}
