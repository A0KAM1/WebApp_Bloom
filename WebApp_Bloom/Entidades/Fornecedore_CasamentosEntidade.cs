﻿namespace WebApp_Bloom.Entidades
{
    public class Fornecedore_CasamentosEntidade
    {
        public int Id { get; set; }
        public CasamentoEntidade Casamento { get; set; }
        public int CasamentoId { get; set; }
        public FornecedorEntidade Fornecedor { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public string Descricao { get; set; }
    }
}
