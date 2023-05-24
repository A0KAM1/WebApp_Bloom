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
    }
}
