namespace SistemaMerceariaWebAPP.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public double Valor { get; set; }
        public int Estoque { get; set; }
      //  public IEnumerable<ProdutoVenda>? Vendas { get; set; }
    }
}
