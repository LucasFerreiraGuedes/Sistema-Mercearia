using Api_SistemaMercearia.Models.User;

namespace Api_SistemaMercearia.DTO_s
{
    public class PatchPasswordUserDTO
    {
        public int Id { get; set; }
        public string Senha { get; set; }

        public PatchPasswordUserDTO(int id, string senha)
        {
            Id = id;
            Senha = UserCryptographyPassword.Cryptography(senha);
        }
    }
}
