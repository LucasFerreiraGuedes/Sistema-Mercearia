using System.ComponentModel.DataAnnotations;

namespace Api_SistemaMercearia.Models.User
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        [StringLength(2)]
        public string? UF { get; set; }

        public Usuario(string name, string email, string senha, string telefone, string uF)
        {
            Name = name;
            Email = email;
            Telefone = telefone;
            UF = uF;
            if (senha.Length > 20)
            {
                Senha = senha;
            }
            else
            {
                Senha = UserCryptographyPassword.Cryptography(senha);
            }
        }
    }
}
