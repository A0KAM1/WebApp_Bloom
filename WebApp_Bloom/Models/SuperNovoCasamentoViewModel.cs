using WebApp_Bloom.Entidades;

namespace WebApp_Bloom.Models
{
    public class SuperNovoCasamentoViewModel
    {
        public int Id { get; set; }
        public int Anfitriao1 { get; set; }
        public int Anfitriao2 { get; set; }
        public Boolean Ativo { get; set; }

        public string data { get; set; }
        public string hora { get; set; }

        public string ListaConvidados { get; set; }
        public string Mesa { get; set; }
        public string ListaFornecedor { get; set; }

    }
}
