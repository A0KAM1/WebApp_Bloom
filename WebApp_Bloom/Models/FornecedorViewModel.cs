using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            Lista = new List<FornecedorEntidade>();
        }
        public List<FornecedorEntidade> Lista { get; set; }

        public int CasamentoId { get; set; }

        public List<Fornecedore_CasamentosEntidade> FornecedoresdoCasamento { get; set; }
    }
}
