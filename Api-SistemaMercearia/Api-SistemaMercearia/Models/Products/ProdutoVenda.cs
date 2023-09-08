namespace Api_SistemaMercearia.Models.Products
{
    public class ProdutoVenda
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int QuantidadeVendida { get; set; }

        public ProdutoVenda(int produtoId, Produto produto, int vendaId, Venda venda, int quantidadeVendida)
        {
            ProdutoId = produtoId;
            Produto = produto;
            VendaId = vendaId;
            Venda = venda;
            QuantidadeVendida = quantidadeVendida;
        }
        public ProdutoVenda()
        {

        }
    }
}
