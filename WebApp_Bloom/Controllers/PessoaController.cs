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

        [HttpPost]
        public IActionResult SalvarDados(PessoaEntidade dados, string urlRedirect)
        {
            dados.RG = dados.RG.Replace(".", "");
            dados.RG = dados.RG.Replace("-", "");
            db.PESSOAS.Add(dados);
            db.SaveChanges();
            if (string.IsNullOrEmpty(urlRedirect))
            {
                return RedirectToAction("Lista");
            }
            else
            {
                return Redirect(urlRedirect);
            }
            
        }
    }
}
