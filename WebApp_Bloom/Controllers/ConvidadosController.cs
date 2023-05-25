using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Bloom.Entidades;
using WebApp_Bloom.Models;

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
            CasamentoViewModel model = new CasamentoViewModel();
            model.Lista = db.CONVIDADOS.ToList();
            return View(model);
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
        public IActionResult SalvarDados(ConvidadosEntidade dados, string urlRedirect)
        {
            db.CONVIDADOS.Add(dados);
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
