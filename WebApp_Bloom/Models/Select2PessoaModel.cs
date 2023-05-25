using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class Select2PessoaModel : PessoaEntidade
    {
        public Select2PessoaModel()
        {
            Lista = new List<PessoaEntidade>();
        }
        public List<PessoaEntidade> Lista { get; set; }
    }
}
