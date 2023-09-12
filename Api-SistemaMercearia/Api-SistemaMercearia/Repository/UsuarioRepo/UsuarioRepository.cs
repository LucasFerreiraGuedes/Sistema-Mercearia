using Api_SistemaMercearia.Context;
using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaMercearia.Repository.UsuarioRepo
{
    public class UsuarioRepository : IUsuarioRepository
	{
		private readonly ContextDb _contextDb;
        public UsuarioRepository(ContextDb context)
        {
            _contextDb = context;
        }
        public async Task<bool> Add<T>(T entity) where T : class
		{
			if (entity != null && entity is Usuario)
			{
				Usuario user = entity as Usuario;
				_contextDb.Add(user);
				await _contextDb.SaveChangesAsync();

				return true;

			}
			return false;
		}

        public async Task<Usuario> AlterarInformacoesAsync(Usuario usuario)
        {
            Usuario user = await GetUserById(usuario.Id);

			if(user != null)
			{
				user = usuario;
				_contextDb.Update(user);
				_contextDb.SaveChanges();
				return user;
			}
			return null;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsers()
        {
			return _contextDb.Usuarios;
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            Usuario user = await _contextDb.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

			if(user != null)
			{
				return user;
			}
			return null;
        }

        public async Task<Usuario> GetUserById(int id)
		{
			Usuario user = await _contextDb.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
			return user;
		}

        public async Task<bool> Login(string email, string password)
        {
            string senhaCriptografada = UserCryptographyPassword.Cryptography(password);

            var usuario = await _contextDb.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senhaCriptografada);

			if(usuario == null) 
			{
				return false;
			}
			return true;

        }

        public async Task<Usuario> PatchPasswordUser(PatchPasswordUserDTO userDTO)
        {
           Usuario user = await GetUserById(userDTO.Id);

			if(user!= null)
			{
				user.Senha = userDTO.Senha;
				_contextDb.Update(user);
				_contextDb.SaveChanges();
				return user;
			}
			return null;
        }
    }
}
