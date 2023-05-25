using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var Lista = new List<Select2PessoaModel>();
            
            return RedirectToAction("Cadastrar", "Casamento");
            
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
