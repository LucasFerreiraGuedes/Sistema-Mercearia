using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaMercearia.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
        public ProdutoController()
        {
            
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            return Ok("ok");
        }

		[HttpPut]
		public ActionResult PutProduct(int id)
		{
			return Ok("ok");
		}

		[HttpPatch]
		public ActionResult PatchProduct(int id)
		{
			return Ok("ok");
		}

		[HttpDelete]
		public ActionResult DeleteProduct(int id)
		{
			return Ok("ok");
		}

		
	}
}
