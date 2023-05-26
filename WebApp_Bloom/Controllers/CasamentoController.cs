using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;
using WebApp_Bloom.Models;

namespace WebApp_Bloom.Controllers
{
    public class CasamentoController : Controller
    {
        public Contexto db;
        public CasamentoController(Contexto opt)
        {
            db = opt;
        }
        public IActionResult Lista(string q)
        {
           
            
            return RedirectToAction("Cadastrar");
            
        }
        public IActionResult Cadastrar()
        {
            Select2PessoaModel Model = new Select2PessoaModel();
            Model.Lista = db.PESSOA.ToList();
            return View(Model);
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
