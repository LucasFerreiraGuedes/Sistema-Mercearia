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
        public async Task<List<Produto>> GetAllProducts()
        {
			var products = await _context.GetAllProducts();
			List<ProdutoDTO> result = _mapper.Map<IEnumerable<ProdutoDTO>>(products).ToList();
			return products.ToList();
        }

		[HttpGet("{id}")]
		public async Task<Produto>GetProductById(int id)
		{
			var product = await _context.GetProductById(id);
			return product;
		}


		[HttpPost]
		public async Task<IActionResult> Add(ProdutoDTO productDTO)
		{
			var product = _mapper.Map<Produto>(productDTO);

			var resposta = await _context.Add(product);

			if (resposta)
			{
				return Ok("Produto Adicionado com sucesso");
			}
			throw new Exception("O produto não pode ser nulo");

		}

		[HttpPut]
		public async Task<ActionResult> PutProduct(Produto produto)
		{
			await _context.PutProduct(produto);
			return Ok();
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
                return Ok("Produto apagado com sucesso");
            }

			throw new Exception("Não existe produto presente no banco que contenha este ID");

		}


	}
}
