using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models;
using Api_SistemaMercearia.Repository.ProdutoRepo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaMercearia.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoRepository _context;
		private readonly IMapper _mapper;
        public ProdutoController(IProdutoRepository context, IMapper mapper)
        {
            _context = context;
			_mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProdutoDTO>> GetAllProducts()
        {
			var products = await _context.GetAllProducts();
			List<ProdutoDTO> result = _mapper.Map<IEnumerable<ProdutoDTO>>(products).ToList();
			return result;
        }
		[HttpPost]
		public async Task<IActionResult> Add(ProdutoDTO productDTO)
		{
			var product = _mapper.Map<Produto>(productDTO);

			var resposta = await _context.Add(product);

			if (resposta)
			{
				return Ok("deu bom");
			}
			return BadRequest("Vish");

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
		public async Task<ActionResult> DeleteProduct(int id)
		{
			var resposta = await _context.DeleteProduct(id);

			if (resposta)
			{
				return Ok("deu bom");
			}
			return BadRequest("Vish");

		}


	}
}
