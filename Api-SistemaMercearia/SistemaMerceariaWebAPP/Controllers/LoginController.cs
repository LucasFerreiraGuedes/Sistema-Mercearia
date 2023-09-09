using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SistemaMerceariaWebAPP.Models;
using SistemaMerceariaWebAPP.Services.Session;

namespace SistemaMerceariaWebAPP.Controllers
{
    public class LoginController : Controller
    {
        private RestClient client;
        private readonly ISessionUser _sessionUser;

        public LoginController(ISessionUser sessionUser)
        {
            _sessionUser = sessionUser;
        }
        public IActionResult Index()
        {
            //Caso o usuário esteja logado, eu o redireciono para a tela seguinte e não para a de login

            if (_sessionUser.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("TodosUsuarios", "Usuario");
            }
            return View();
        }
        public async Task<ActionResult> LoginUser(Usuario user)
        {
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario/login", Method.Post);

            var usuario = new
            {
                Email = $"{user.Email}",
                Senha = $"{user.Senha}"
            };
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(usuario);

            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                //Caso o login seja feito com sucesso, eu recupero todas as informações do usuário

                request = new RestRequest("https://localhost:7123/api/Usuario/GetUserByEmail?email=" + user.Email, Method.Get);
                response = await client.ExecuteAsync(request);

                user = JsonConvert.DeserializeObject<Usuario>(response.Content);

                _sessionUser.CriarSessaoUsuario(user);
                return RedirectToAction("TodosUsuarios", "Usuario");
                
            }
            TempData["MensagemErro"] = $"E-mail ou senha inválidos, por favor tente novamente";
            return RedirectToAction("Index");
        }
    }
}
