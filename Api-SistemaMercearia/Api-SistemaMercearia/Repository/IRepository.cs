namespace Api_SistemaMercearia.Repository
{
	public interface IRepository
	{
		public Task<bool> Add<T> (T entity) where T : class;
	}
}
