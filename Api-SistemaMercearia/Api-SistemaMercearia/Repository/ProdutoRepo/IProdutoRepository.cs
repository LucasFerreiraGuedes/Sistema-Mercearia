using Api_SistemaMercearia.Models;

namespace Api_SistemaMercearia.Repository.ProdutoRepo
{
	public interface IProdutoRepository : IRepository
	{
		Task<IEnumerable<Produto>> GetAllProducts();
		Task<Boolean> DeleteProduct(int id);

		Task<Produto> PutProduct(int id,Produto produto);
	}
}
