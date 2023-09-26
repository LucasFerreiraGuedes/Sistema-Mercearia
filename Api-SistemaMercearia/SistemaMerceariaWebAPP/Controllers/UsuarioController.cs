using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestSharp;
using SistemaMerceariaWebAPP.Models;
using SistemaMerceariaWebAPP.Services.Session;

namespace SistemaMerceariaWebAPP.Controllers
{
	public class UsuarioController : Controller
	{
        private RestClient client;
        private readonly ISessionUser _sessionUser;
        public UsuarioController(ISessionUser sessionUser)
        {
            _sessionUser = sessionUser;
        }
      
        public async Task<ActionResult> CadastrarUsuario()
        {
            client = new RestClient();
            var request = new RestRequest("https://servicodados.ibge.gov.br/api/v1/localidades/estados", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            List<Sigla> siglasEstados = JsonConvert.DeserializeObject<List<Sigla>>(response.Content);

           UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            
            siglasEstados = siglasEstados.OrderBy(x => x.sigla).ToList();

            foreach (var item in siglasEstados)
            {
                usuarioViewModel.SiglasEstado.Add(new SelectListItem { Text = item.sigla, Value = item.sigla} );
            }
            
            //Os metódos acima são responsáveis por realizar o consumo de uma API do governo federal, na qual me provém a sigla de todos os estados do País.
            //Eu consumo esta informação e a coloco em um dropdown de seleção para o usuário

            return View(usuarioViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CadastroUsuario(UsuarioViewModel usuarioViewModel)
        {
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(usuarioViewModel.Usuario);

            RestResponse response = await client.ExecuteAsync(request);

            _sessionUser.CriarSessaoUsuario(usuarioViewModel.Usuario);

            return RedirectToAction("GetAllUsers");
        }

        public async Task<ActionResult> GetAllUsers()
        {
            // Método responsável por recuperar todos os usuários

            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario/AllUsers", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            if(response.IsSuccessful)
            {

                List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response.Content);
                return View("Usuarios", usuarios);
            }

            TempData["MensagemErro"] = "Não há nenhum usuário cadastrado!";
            return View("Usuarios");

        }
        public IActionResult Perfil()
        {
            Usuario usuario = new Usuario();
            usuario = _sessionUser.BuscarSessaoUsuario();


            if (usuario != null)
            {

                //client = new RestClient();
                //var request = new RestRequest("https://localhost:7123/api/Usuario/GetUserByEmail?email=" + usuario.Email, Method.Get);

                //RestResponse response = client.Execute(request);
                //usuario = JsonConvert.DeserializeObject<Usuario>(response.Content);

                return View(usuario);
                
            }
            return View();
            
        }
        public IActionResult EditarInformacoes()
        {
            var usuario = _sessionUser.BuscarSessaoUsuario();
            return View(usuario);
        }
        public IActionResult SalvarAtualizacaoInformacoes(Usuario usuario)
        {
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario", Method.Put);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(usuario);

            RestResponse response = client.Execute(request);

            _sessionUser.RemoverSessaoUsuario();
            _sessionUser.CriarSessaoUsuario(usuario);

            return View("Perfil",usuario);

        }
       
    }
}
