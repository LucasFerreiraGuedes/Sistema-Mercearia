﻿using Api_SistemaMercearia.Models.User;

namespace Api_SistemaMercearia.Repository.UsuarioRepo
{
    public interface IUsuarioRepository : IRepository
	{
	     Task<Usuario> GetUserById(int id);
		Task<IEnumerable<Usuario>> GetAllUsers();

		Task<bool> Login(string email, string password);

	}
}
