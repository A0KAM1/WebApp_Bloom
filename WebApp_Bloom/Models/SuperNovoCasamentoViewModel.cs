using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class SuperNovoCasamentoViewModel
    {
        public int Anfitriao1 { get; set; }
        public int Anfitriao2 { get; set; }

        public string data { get; set; }
        public string hora { get; set; }

        public string ListaConvidados { get; set; }
        public List<int> ListaFornecedores { get; set; }
        public List<SuperNovoCasamentoViewModel> TodosCasamentos { get; set; }
    }
}
