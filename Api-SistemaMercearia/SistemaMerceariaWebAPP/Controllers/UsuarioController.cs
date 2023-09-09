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

        public async Task<ActionResult> TodosUsuarios()
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
       
    }
}
