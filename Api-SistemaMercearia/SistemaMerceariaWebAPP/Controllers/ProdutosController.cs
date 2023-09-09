using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SistemaMerceariaWebAPP.Models;

namespace SistemaMerceariaWebAPP.Controllers
{
	public class ProdutosController : Controller
	{
		private RestClient client;
		public async Task<IActionResult> Index()
		{
			client = new RestClient();
			var request = new RestRequest("https://localhost:7123/api/Produto", Method.Get);

			RestResponse response = await client.ExecuteAsync(request);

			if(response.IsSuccessful)
			{
                List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(response.Content);

                return View(produtos);
            }
			return View();
			
		}

		public IActionResult AdicionarProduto()
		{
			 return View();
		}
		
		public async Task<IActionResult> Criar(Produto produto)
		{
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Produto", Method.Post);
			request.RequestFormat = DataFormat.Json;
			request.AddJsonBody(produto);

            RestResponse response = await client.ExecuteAsync(request);

            //List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(response.Content);

            return RedirectToAction("Index");
        }
		public async Task<IActionResult> Apagar(int id)
		{
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Produto?id=" + id, Method.Delete);

            RestResponse response = await client.ExecuteAsync(request);


			return RedirectToAction("Index");
        }
		public async Task<IActionResult> EditarProduto(int id)
		{
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Produto/"+ id, Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            Produto produto = JsonConvert.DeserializeObject<Produto>(response.Content);

            return View(produto);
        }
		public async Task<IActionResult> SalvarAlteracoes(Produto produto)
		{
            client = new RestClient();
            var request = new RestRequest("https://localhost:7123/api/Produto", Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(produto);

            RestResponse response = await client.ExecuteAsync(request);


			return RedirectToAction("Index"); 
        }

    }
}
