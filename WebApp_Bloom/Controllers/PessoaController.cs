using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_Bloom.Entidades;
using WebApp_Bloom.Models;

namespace WebApp_Bloom.Controllers
{
    public class PessoaController : Controller
    {
        public Contexto db;
        public PessoaController(Contexto opt)
        {
            db = opt;
        }
        
        public IActionResult SalvarDados(PessoaEntidade dados)
        {
            db.PESSOAS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Cadastrar","Casamento");
        }
    }
}
