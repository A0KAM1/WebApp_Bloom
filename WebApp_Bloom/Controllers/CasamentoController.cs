using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
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
            
            Pessoas_CasamentoEntidade noivo = new Pessoas_CasamentoEntidade();
            noivo.PessoaId = model.Anfitriao1;
            noivo.CasamentoId = casamento.Id;
            noivo.Ativo = false;
            db.PESSOAS_CASAMENTOS.Add(noivo); 
            db.SaveChanges();

            Pessoas_CasamentoEntidade noivo1 = new Pessoas_CasamentoEntidade();
            noivo1.PessoaId = model.Anfitriao2;
            noivo1.CasamentoId = casamento.Id;
            noivo1.Ativo = false;
            db.PESSOAS_CASAMENTOS.Add(noivo1);
            db.SaveChanges();

            //CronogramaEntidade dia = new CronogramaEntidade();
            //model.data = model.data.Replace("/", "");
            //dia.Dia = model.data;
            //dia.CasamentoId = casamento.Id;
            //db.CRONOGRAMAS.Add(dia);
            //db.SaveChanges();

            foreach (var item in model.ListaConvidados.Split(","))
            {
                Pessoas_CasamentoEntidade novoConvidado = new Pessoas_CasamentoEntidade();
                novoConvidado.PessoaId = int.Parse(item);
                novoConvidado.CasamentoId = casamento.Id;
                novoConvidado.Ativo = true;
                db.PESSOAS_CASAMENTOS.Add(novoConvidado);
                db.SaveChanges();
            }

            foreach (var item in model.ListaFornecedor.Split(","))
            {
                //var x = 0;
                Fornecedore_CasamentosEntidade novoFornecedor = new Fornecedore_CasamentosEntidade();
                novoFornecedor.FornecedorId = int.Parse(item);
                novoFornecedor.CasamentoId = casamento.Id;
                //foreach (var i in model.ListaProduto.Split(","))
                //{
                //    var y = 0;
                //    if(x == y)
                //    {
                //        novoFornecedor.ProdutoId = int.Parse(i);
                //    }
                //    y++;
                //}
                //x++;
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
        [Route("[controller]/[action]/{casamentoId}")]
        public IActionResult Editar(int casamentoId)
        {
            SuperNovoCasamentoViewModel model = new SuperNovoCasamentoViewModel();
            model.Id = casamentoId;
            //model.Anfitriao1 = db.PESSOAS_CASAMENTOS.Where(a => a.CasamentoId == casamentoId).Where(a => a.Ativo == false).Include(a => a.PessoaId).Include(a => a.Pessoa.Nome).FirstOrDefault().Pessoa;
            //model.Anfitriao2 = db.PESSOAS_CASAMENTOS.Where(a => a.CasamentoId == casamentoId).Where(a => a.Ativo == false).Include(a => a.PessoaId).Include(a => a.Pessoa.Nome).LastOrDefault().Pessoa;
            return View(model);
        }

        public IActionResult ListaConvidados(int id)
        {

            ConvidadosViewModel model = new ConvidadosViewModel();
            model.ConvidadosParaCasamento = db.PESSOAS_CASAMENTOS.Where(a => a.CasamentoId == id).Include(a => a.Pessoa).Include(a => a.Casamento).Where(a => a.Ativo == true).ToList();
            model.CasamentoId = id;
            return View(model);
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
        
        public IActionResult EditarConvidados(PessoaEntidade convidado)
        {
            if (convidado != null)
            {
                return View(convidado);
            }
            else
            {
                return RedirectToAction("ListaConvidados");
            }
        }
        public IActionResult ExcluirConvidado(Pessoas_CasamentoEntidade id,Pessoas_CasamentoEntidade dados)
        {
            if (id != null)
            {
                db.PESSOAS_CASAMENTOS.Remove(dados);
                db.SaveChanges();
            }
            return RedirectToAction("ListaConvidados");
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
        public IActionResult ListaFornecedor(int casamentoId)
        {
            FornecedorViewModel model = new FornecedorViewModel();
            model.FornecedoresdoCasamento = db.FORNECEDORES_CASAMENTOS.Where(a => a.CasamentoId == casamentoId).Include(a => a.Fornecedor).Include(a => a.Casamento).Include(a => a.Produto).ToList();
            model.CasamentoId = casamentoId;
            return View(model);
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
        public IActionResult EditarFornecedor(FornecedorEntidade fornecedor)
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
