using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class CasamentoViewModel : CasamentoEntidade
    {
        public CasamentoViewModel()
        {
            Lista = new List<Pessoas_CasamentoEntidade>();
        }
        public List<Pessoas_CasamentoEntidade> Lista { get; set; }
    }
    }
