using Api_SistemaMercearia.Models.User;
using Api_SistemaMercearia.Repository.UsuarioRepo;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaMercearia.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
        private readonly IUsuarioRepository _context;
        public UsuarioController(IUsuarioRepository context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var user = await _context.GetUserById(id); 
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);    
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario user)
        {
           await _context.Add(user);
            return Ok();
        }

        [HttpGet("login")]
        public async Task<ActionResult> LoginUser(string email,string senha)
        {
            bool response = await _context.Login(email, senha);
            if (response)
            {
                return Ok();
            }
            return Unauthorized();
        }
         
    }
}
