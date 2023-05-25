using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class CasamentoViewModel : CasamentoEntidade
    {
        public CasamentoViewModel()
        {
            Lista = new List<ConvidadosEntidade>();
        }
        public List<ConvidadosEntidade> Lista { get; set; }
    }
    }
