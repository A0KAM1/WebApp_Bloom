namespace WebApp_Bloom.Entidades
{
    public class Pessoas_CasamentoEntidade
    {
        public int Id { get; set; }
        public CasamentoEntidade Casamento { get; set; }
        public int CasamentoId { get; set; }
        public PessoaEntidade Pessoa { get; set; }
        public int PessoaId { get; set; }
        public int? Mesa { get; set; }
    }
}
