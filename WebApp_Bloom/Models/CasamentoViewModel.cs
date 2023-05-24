using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class CasamentoViewModel : CasamentoEntidade
    {
        List<ConvidadosEntidade>ListaConvidados { get; set; }
        List<FornecedorEntidade>ListaFornecedor { get; set; }
    }
}
