using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SistemaMerceariaWebAPP.Models;

namespace SistemaMerceariaWebAPP.Controllers
{
	public class UsuarioController : Controller
	{
        private RestClient client;
        public UsuarioController()
        {
            
        }
        public async Task<ActionResult> Login()
        {
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
                return RedirectToAction("RecuperarTodosUsuarios");
                //return RedirectToAction("Index","Produtos");
            }
            return View("Usuarios");
        }
        public async Task<ActionResult> CadastrarUsuario()
        {
        //    client = new RestClient();
        //    var request = new RestRequest("https://servicodados.ibge.gov.br/api/v1/localidades/estados", Method.Get);

        //    RestResponse response = await client.ExecuteAsync(request);
        //    List<Sigla> produtos = JsonConvert.DeserializeObject<List<Sigla>>(response.Content);

        //    List<string> siglas = new List<string>();
        //    foreach(var item in produtos)
        //    {
        //        siglas.Add(item.sigla);
        //    }
        //    Usuario user = new Usuario();
            
           // return View(produtos);

            return View();
        }

        public async Task<ActionResult> CadastroUsuario(Usuario user)
        {
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);

            RestResponse response = await client.ExecuteAsync(request);


            return RedirectToAction("CadastrarUsuario");
        }

        public async Task<ActionResult> RecuperarTodosUsuarios()
        {
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Usuario/AllUsers", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            // Fazer a tratativa do Response aqui

            return View("Usuarios",response);

        }
       
    }
}
