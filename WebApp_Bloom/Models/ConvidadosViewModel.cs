using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class ConvidadosViewModel : PessoaEntidade
    {
        public ConvidadosViewModel()
        {
            Lista = new List<PessoaEntidade>();
        }
        public List<PessoaEntidade> Lista { get; set; }
    }
}