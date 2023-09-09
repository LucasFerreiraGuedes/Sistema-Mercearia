using SistemaMerceariaWebAPP.Models;

namespace SistemaMerceariaWebAPP.Services.Session
{
    public interface ISessionUser
    {
        void CriarSessaoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoUsuario();
    }
}
