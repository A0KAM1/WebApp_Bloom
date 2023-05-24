using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class PessoaController : Controller
    {
        public Contexto db;
        public PessoaController(Contexto opt)
        {
            db = opt;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SalvarDados(PessoaEntidade dados)
        {
            db.PESSOAS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("/Casamento/Cadastrar");
        }
    }
}
