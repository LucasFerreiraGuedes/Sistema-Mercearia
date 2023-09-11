using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaMerceariaWebAPP.Models
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public List<SelectListItem> SiglasEstado = new List<SelectListItem>();
    }
}
