using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models.User;

namespace Api_SistemaMercearia.Repository.UsuarioRepo
{
    public interface IUsuarioRepository : IRepository
	{
	     Task<Usuario> GetUserById(int id);
		Task<IEnumerable<Usuario>> GetAllUsers();
		
		Task<Usuario> GetUserByEmailAsync(string email);

		Task<bool> Login(string email, string password);

		Task<Usuario> AlterarInformacoesAsync(Usuario usuario);

		Task<Usuario> PatchPasswordUser(PatchPasswordUserDTO userDTO);

		Task<Boolean> DeleteAsync(int id);

	}
}
