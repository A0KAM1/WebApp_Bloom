using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult SalvarDados(SuperNovoCasamentoViewModel model) 
        {
            CasamentoEntidade casamento = new CasamentoEntidade();
            db.CASAMENTOS.Add(casamento);
            db.SaveChanges();

            foreach (var item in model.ListaConvidados.Split(","))
            {
                Pessoas_CasamentoEntidade novoConvidado = new Pessoas_CasamentoEntidade();
                novoConvidado.PessoaId = int.Parse(item);
                novoConvidado.CasamentoId = casamento.Id;
                db.PESSOAS_CASAMENTOS.Add(novoConvidado);
                db.SaveChanges();
            }

            foreach (var item in model.ListaFornecedores)
            {
                Fornecedore_CasamentosEntidade novoFornecedor = new Fornecedore_CasamentosEntidade();
                novoFornecedor.FornecedorId = item;
                novoFornecedor.CasamentoId = casamento.Id;
                db.FORNECEDORES_CASAMENTOS.Add(novoFornecedor);
                db.SaveChanges();
            }


            return RedirectToAction("Evento","Evento");
        }
        public IActionResult Cadastrar()
        {
            Select2PessoaModel Model = new Select2PessoaModel();
            Model.Lista = db.PESSOA.ToList();
            return View(Model);
        }
        
        //public IActionResult SalvarDados(Pessoas_CasamentoEntidade casamento)
        //{
        //    db.PESSOAS_CASAMENTOS.Add(casamento);
        //    db.SaveChanges();
        //    return RedirectToAction("Cadastrar"); 
            
        //}
        public IActionResult Editar()
        {
            
            return View();
        }

        public IActionResult Convidados(int id)
        {
             ConvidadosViewModel model = new ConvidadosViewModel();
            model.ConvidadosParaCasamento = db.PESSOAS_CASAMENTOS.Where(a => a.CasamentoId == id).Include(a => a.Pessoa).Include(a => a.Casamento).ToList();
            model.ListaTodasPessoasCadastradasNoSistema = db.PESSOA.ToList();
            model.CasamentoId = id
;            return View(model);
        }

        [Route("[controller]/[action]/{casamentoId}/{pessoaId}")]
        public IActionResult AddConvidado(int casamentoId, int pessoaId) 
        {
            Pessoas_CasamentoEntidade novo = new Pessoas_CasamentoEntidade();
            novo.CasamentoId = casamentoId;
            novo.PessoaId = pessoaId;
            db.PESSOAS_CASAMENTOS.Add(novo);
            db.SaveChanges();
            return Redirect("/Casamento/Convidados/" + casamentoId);
        }
    }
}
