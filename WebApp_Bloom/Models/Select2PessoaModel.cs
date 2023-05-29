using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class Select2PessoaModel : PessoaEntidade
    {
        public Select2PessoaModel()
        {
            Lista = new List<PessoaEntidade>();
            ListaFornecedor = new List<FornecedorEntidade>();
        }
        public List<PessoaEntidade> Lista { get; set; }
        public List<FornecedorEntidade> ListaFornecedor { get; set; }
        public List<ProdutoEntidade> Produto { get; set; }

    }
}
