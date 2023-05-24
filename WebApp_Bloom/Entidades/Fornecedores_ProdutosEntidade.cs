namespace WebApp_Bloom.Entidades
{
    public class Fornecedores_ProdutosEntidade
    {
        public long Id { get; set; }
        public long FornecedorId { get; set; }
        public long ProdutoId { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public FornecedorEntidade Fornecedor { get; set; }
    }
}
