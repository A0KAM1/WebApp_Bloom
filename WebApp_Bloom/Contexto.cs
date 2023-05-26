using Microsoft.EntityFrameworkCore;
using WebApp_Bloom.Entidades;

namespace WebApp_Bloom
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt)
        {

        }

        public DbSet<FornecedorEntidade> FORNECEDORES { get; set; }
        public DbSet<Fornecedores_ProdutosEntidade> FORNECEDORES_PRODUTOS { get; set; }
        public DbSet<Fornecedore_CasamentosEntidade> FORNECEDORES_CASAMENTOS { get; set; }
        public DbSet<Pessoas_CasamentoEntidade> PESSOAS_CASAMENTOS { get; set; }
        public DbSet<CasamentoEntidade> CASAMENTOS { get; set; }
        public DbSet<PessoaEntidade> PESSOA { get; set; }
        public DbSet<CronogramaEntidade> CRONOGRAMAS { get; set; }
        public DbSet<EventosEntidade> EVENTOS { get; set; }
        public DbSet<Cronogramas_EventosEntidade> CRONOGRAMAS_EVENTOS { get; set; }

    }
}
