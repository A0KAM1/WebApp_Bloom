namespace WebApp_Bloom.Entidades
{
    public class Casamentos_FornecedoresEntidade
    {
        public int Id { get; set; }
        public CasamentoEntidade Casamento { get; set; }

        public int CasamentoId { get; set; }
        public FornecedorEntidade Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
