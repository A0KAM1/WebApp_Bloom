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
        public DbSet<ConvidadosEntidade> CONVIDADOS { get; set; }
        public DbSet<CasamentoEntidade> CASAMENTOS { get; set; }
        public DbSet<PessoaEntidade> PESSOAS { get; set; }

    }
}
