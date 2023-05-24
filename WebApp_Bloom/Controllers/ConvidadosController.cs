using Microsoft.AspNetCore.Mvc;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Controllers
{
    public class ConvidadosController : Controller
    {
        public Contexto db;
        public ConvidadosController(Contexto opt)
        {
            db = opt;
        }
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
        public IActionResult SalvarDados(ConvidadosEntidade dados)
        {
            db.CONVIDADOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("/Casamento/Cadastrar");
        }
    }
}
