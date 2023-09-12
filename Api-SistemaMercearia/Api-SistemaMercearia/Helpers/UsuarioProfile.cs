using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_SistemaMercearia.Helpers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario,PatchPasswordUserDTO>().ReverseMap();
        }
    }
}
