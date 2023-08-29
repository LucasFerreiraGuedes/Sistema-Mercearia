using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SistemaMerceariaWebAPP.Models;

namespace SistemaMerceariaWebAPP.Controllers
{
	public class ProdutosController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new RestClient();
			var request = new RestRequest("https://localhost:7123/api/Produto", Method.Get);

			RestResponse response = await client.ExecuteAsync(request);
			List<Produtos> produtos = JsonConvert.DeserializeObject<List<Produtos>>(response.Content);

			return View(produtos);
		}
	}
}
