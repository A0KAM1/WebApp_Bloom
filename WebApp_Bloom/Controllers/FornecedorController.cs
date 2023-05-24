using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class FornecedorController : Controller
    {
        private Contexto db;
        public FornecedorController(Contexto contexto)
        {
            db = contexto;
        }

        public IActionResult Lista()
        {
            return View(db.FORNECEDORES.ToList());
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
