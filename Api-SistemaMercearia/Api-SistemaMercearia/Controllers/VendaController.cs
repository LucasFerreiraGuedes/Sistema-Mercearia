using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models;
using Api_SistemaMercearia.Repository.VendaRepo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaMercearia.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendaController : ControllerBase
	{
        private readonly IVendaRepository _context;
        private readonly IMapper _mapper;
        public VendaController(IVendaRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        
        public async Task<IActionResult> Add(VendaDTO vendaDTO)
        {
            Venda venda = _mapper.Map<Venda>(vendaDTO);

            bool result = await _context.Add(venda);

            if(result)
            {
                return Ok(venda);
            }
            return BadRequest();
        }
    }
}
