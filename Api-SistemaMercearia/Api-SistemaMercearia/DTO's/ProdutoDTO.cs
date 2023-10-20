namespace Api_SistemaMercearia.DTO_s
{
	public class ProdutoDTO
	{
        public int Id { get; set; }
		public string Descricao { get; set; }
		public string Marca { get; set; }
		public double Valor { get; set; }
		public int Estoque { get; set; }

		public ProdutoDTO(int id, string descricao, string marca, double valor, int estoque)
		{
			Id = id;
			Descricao = descricao;
			Marca = marca;
			Valor = valor;
			Estoque = estoque;
		}
	}
}
