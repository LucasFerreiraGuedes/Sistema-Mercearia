using Newtonsoft.Json;
using SistemaMerceariaWebAPP.Models;

namespace SistemaMerceariaWebAPP.Services.Session
{
    public class SessionUser : ISessionUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public Usuario BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(sessaoUsuario != null)
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
                return usuario;
            }
            return null;
        }

        public void CriarSessaoUsuario(Usuario usuario)
        {
            string user = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", user);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
