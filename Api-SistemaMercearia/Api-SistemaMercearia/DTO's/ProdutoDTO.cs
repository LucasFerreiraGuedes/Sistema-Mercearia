namespace Api_SistemaMercearia.DTO_s
{
	public class ProdutoDTO
	{
		public int Codigo { get; set; }
		public string Descricao { get; set; }
		public string Marca { get; set; }
		public double Valor { get; set; }
		public int Estoque { get; set; }

		public ProdutoDTO(int codigo, string descricao, string marca, double valor, int estoque)
		{
			Codigo = codigo;
			Descricao = descricao;
			Marca = marca;
			Valor = valor;
			Estoque = estoque;
		}
	}
}
