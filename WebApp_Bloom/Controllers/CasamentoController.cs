using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class CasamentoController : Controller
    {
        public Contexto db;
        public CasamentoController(Contexto opt)
        {
            db = opt;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SalvarDados(CasamentoEntidade casamento)
        {
            db.CASAMENTOS.Add(casamento);
            db.SaveChanges();
            return RedirectToAction("Cadastrar");   
        }
        public IActionResult Editar()
        {
            
            return View();
        }
    }
}
