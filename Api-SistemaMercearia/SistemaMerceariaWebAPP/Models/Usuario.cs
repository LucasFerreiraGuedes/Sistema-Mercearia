using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace SistemaMerceariaWebAPP.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [StringLength(14, ErrorMessage = "A senha deve conter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Senha { get; set; }
        public string Telefone { get; set; }

        [StringLength(2)]
        public string? UF { get; set; }

        public Usuario()
        {
            
        }
        public Usuario(string name, string email, string senha, string telefone, string uF)
        {
            Name = name;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            UF = uF;
        }
    }
}
