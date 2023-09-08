namespace Api_SistemaMercearia.Models.Products
{
    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public double Valor { get; set; }
        public int Estoque { get; set; }
        public IEnumerable<ProdutoVenda>? Vendas { get; set; }

        public Produto(string descricao, string marca, double valor, int estoque)
        {
            Descricao = descricao;
            Marca = marca;
            Valor = valor;
            Estoque = estoque;
        }
    }
}
