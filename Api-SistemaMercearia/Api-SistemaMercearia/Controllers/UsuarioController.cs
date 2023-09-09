using Api_SistemaMercearia.DTO_s;
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

        [HttpGet("AllUsers")]
        public async Task<ActionResult<List<Usuario>>> GetAllUsers()
        {
            IEnumerable<Usuario> usuarios = await _context.GetAllUsers();

            if(usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);

        } 

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario user)
        {
           await _context.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUsuarioDTO usuarioDTO)
        {
            bool response = await _context.Login(usuarioDTO.Email,usuarioDTO.Senha);
            if (response)
            {
                return Ok();
            }
            return Unauthorized();
        }
         
    }
}
