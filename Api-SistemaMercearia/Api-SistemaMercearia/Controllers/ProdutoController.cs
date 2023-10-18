using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models.Products;
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
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAllProducts()
        {

			var products = await _context.GetAllProducts();

			if(products.Count() > 0) 
			{
				List<ProdutoDTO> result = _mapper.Map<IEnumerable<ProdutoDTO>>(products).ToList();

				result.ForEach(x => x.Valor = Math.Round(x.Valor,2));

				return Ok(result);
			}
			var problemDetails = new ProblemDetails()
			{
				Title = "Não há nenhum produto cadastrado na base de dados",
				Status = 404

			};
			return NotFound(problemDetails);

			
			
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ProdutoDTO>> GetProductById(int id)
		{
			var product = await _context.GetProductById(id);

			if(product != null)
			{
				var productDTO = _mapper.Map<ProdutoDTO>(product);
				return Ok(productDTO);
			}
			return NotFound();
			
		}


		[HttpPost]
		public async Task<IActionResult> Add(ProdutoDTO productDTO)
		{
			var product = _mapper.Map<Produto>(productDTO);

			var resposta = await _context.Add(product);

			if (resposta)
			{
				return Ok();
			}
			throw new Exception("O produto não pode ser nulo");

		}

		[HttpPut("{id}")]
		public async Task<ActionResult> PutProduct(int id,ProdutoDTO produto)
		{
			var product = _mapper.Map<Produto>(produto);
			await _context.PutProduct(product);
			return Ok();
		}

		[HttpPatch]
		public ActionResult PatchProduct(int id)
		{
			return Ok("ok");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteProduct(int id)
		{

            var resposta = await _context.DeleteProduct(id);

            if (resposta)
            {
                return Ok();
            }

			var problemDetails = new ProblemDetails()
			{
				Title = "Não existe produto no Banco de Dados que contenha este ID",
				Status = 400,
				
			};
			return BadRequest(problemDetails);

		}


	}
}
