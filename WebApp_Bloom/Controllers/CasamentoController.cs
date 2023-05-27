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

            foreach (var item in model.ListaFornecedor.Split(","))
            {
                Fornecedore_CasamentosEntidade novoFornecedor = new Fornecedore_CasamentosEntidade();
                novoFornecedor.FornecedorId = int.Parse(item);
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
            Model.ListaFornecedor = db.FORNECEDORES.ToList();
            Model.Produto = db.PRODUTOS.ToList();
            return View(Model);
        }  
        public IActionResult Editar()
        {
            
            return View();
        }

        public IActionResult ListaConvidados(int id)
        {

            ConvidadosViewModel model = new ConvidadosViewModel();
            model.ConvidadosParaCasamento = db.PESSOAS_CASAMENTOS.Where(a => a.CasamentoId == id).Include(a => a.Pessoa).Include(a => a.Casamento).ToList();
            model.CasamentoId = id;
            ; return View(model);
        }

        [Route("[controller]/[action]/{casamentoId}/{pessoaId}")]
        public IActionResult AddConvidado(int casamentoId, int pessoaId) 
        {
            Pessoas_CasamentoEntidade novo = new Pessoas_CasamentoEntidade();
            novo.CasamentoId = casamentoId;
            novo.PessoaId = pessoaId;
            db.PESSOAS_CASAMENTOS.Add(novo);
            db.SaveChanges();
            return Redirect("/Casamento/ListaConvidado/" + casamentoId);
        }

        public IActionResult EditarConvidados(Pessoas_CasamentoEntidade convidado)
        {
            if (convidado != null)
            {
                return View(convidado);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }

        [Route("[controller]/[action]/{casamentoId}/{fornecedorId}")]
        public IActionResult AddFornecedor(int casamentoId, int fornecedorId)
        {
            Fornecedore_CasamentosEntidade novo = new Fornecedore_CasamentosEntidade();
            novo.CasamentoId = casamentoId;
            novo.FornecedorId = fornecedorId;
            db.FORNECEDORES_CASAMENTOS.Add(novo);
            db.SaveChanges();
            return Redirect("/Casamento/ListaFornecedor/" + casamentoId);
        }
        public IActionResult ListaFornecedor(int id)
        {
            FornecedorViewModel model = new FornecedorViewModel();
            model.FornecedoresdoCasamento = db.FORNECEDORES_CASAMENTOS.Where(a => a.CasamentoId == id).Include(a => a.Fornecedor).Include(a => a.Casamento).ToList();
            model.CasamentoId = id;
            ; return View(model);
        }
        public IActionResult SalvarDadosProdutos(ProdutoEntidade dados) 
        {
            db.PRODUTOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Cadastrar");
        }
        public IActionResult SalvarDadosFornecedor(FornecedorEntidade dados)
        {
            dados.Telefone = dados.Telefone.Replace("(", "");
            dados.Telefone = dados.Telefone.Replace(")", "");
            dados.Telefone = dados.Telefone.Replace("-", "");
            dados.Telefone = dados.Telefone.Replace(" ", "");
            db.FORNECEDORES.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Cadastrar");

        }
        public IActionResult Editar(FornecedorEntidade fornecedor)
        {
            if (fornecedor != null)
            {
                return View(fornecedor);
            }
            else
            {
                return RedirectToAction("ListaFornecedor");
            }
        }
    }
}
