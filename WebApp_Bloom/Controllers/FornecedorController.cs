using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class FornecedorController : Controller
    {
        private Contexto db;
        public FornecedorController(Contexto opt)
        {
            db = opt;
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
        public IActionResult SalvarDados(FornecedorEntidade dados)
        {
            db.FORNECEDORES.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Cadastrar", "Casamento");
        }
        
    }
}
