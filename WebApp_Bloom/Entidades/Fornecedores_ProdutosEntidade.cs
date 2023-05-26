namespace WebApp_Bloom.Entidades
{
    public class Fornecedores_ProdutosEntidade
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public FornecedorEntidade Fornecedor { get; set; }
        public string Descricao { get; set; }

    }
}
