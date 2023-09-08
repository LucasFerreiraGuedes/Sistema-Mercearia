using Api_SistemaMercearia.Models.Products;

namespace Api_SistemaMercearia.Repository.ProdutoRepo
{
    public interface IProdutoRepository : IRepository
	{
		Task<IEnumerable<Produto>> GetAllProducts();
		Task<Boolean> DeleteProduct(int id);

		Task<Produto> PutProduct(Produto produto);

		Task<Produto> GetProductById(int id);
	}
}
