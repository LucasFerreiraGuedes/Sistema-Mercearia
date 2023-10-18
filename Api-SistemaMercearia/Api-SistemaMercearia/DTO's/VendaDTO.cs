using Api_SistemaMercearia.Models.Products;

namespace Api_SistemaMercearia.DTO_s
{
	public class VendaDTO
	{
		public double ValorTotal { get; set; }
		public DateTime DataDaVenda { get; set; }

		public VendaDTO(DateTime dataDaVenda, double valorTotal)
		{
			DataDaVenda = DateTime.Now;
			this.ValorTotal = valorTotal;
		}
	}
}
