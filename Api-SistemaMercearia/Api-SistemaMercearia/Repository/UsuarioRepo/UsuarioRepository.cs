﻿using Api_SistemaMercearia.Context;
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

		public async Task<Usuario> GetUserById(int id)
		{
			Usuario user = await _contextDb.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
			return user;
		}

        public async Task<bool> Login(string email, string password)
        {
           var usuario = await _contextDb.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

			if(usuario == null) 
			{
				return false;
			}

			string senhaCriptografada = UserCryptographyPassword.Cryptography(password);

            if (usuario.Senha == senhaCriptografada)
			{
				return true;
			}
			return false;
        }
    }
}
