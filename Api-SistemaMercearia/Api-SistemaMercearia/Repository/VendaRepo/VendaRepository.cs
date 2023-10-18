using Api_SistemaMercearia.Context;
using Api_SistemaMercearia.Models;

namespace Api_SistemaMercearia.Repository.VendaRepo
{
	public class VendaRepository : IVendaRepository
	{
		private readonly ContextDb _contextDb;
        public VendaRepository(ContextDb context)
        {
            _contextDb = context;
        }
        public async Task<bool> Add<T>(T entity) where T : class
		{
			if(entity != null && entity is Venda)
			{
				Venda venda = entity as Venda;
				_contextDb.Add(venda);
				await _contextDb.SaveChangesAsync();
				return true;

			}
			return false;
		}
	}
}
