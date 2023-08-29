using Api_SistemaMercearia.Context;
using Api_SistemaMercearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaMercearia.Repository.ProdutoRepo
{
	public class ProdutoRepository : IProdutoRepository
	{
		private  ContextDb _contextDb;
        public ProdutoRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

		public async Task<IEnumerable<Produto>> GetAllProducts()
		{
			return _contextDb.Produtos;
		}
		public async Task<bool> Add<T>(T entity) where T : class
		{

			try
			{
				if(entity is Produto)
				{
					Produto product = entity as Produto;
					_contextDb.Add(product);
					await _contextDb.SaveChangesAsync();
					return true;
					
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
                await Console.Out.WriteLineAsync("Ocorreu um erro ao tentar salvar o registro, segue a descrição do erro: "+ e.Message);
                throw;
			}
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var product = await _contextDb.Produtos.FirstOrDefaultAsync(x => x.Id == id);
			if(product != null)
			{
				 _contextDb.Remove(product);
				await _contextDb.SaveChangesAsync();
				return true;
			}
			return false;
		}

		

		public async Task<Produto> PutProduct(int id, Produto produto)
		{
			throw new NotImplementedException();
		}
		
	}
}
