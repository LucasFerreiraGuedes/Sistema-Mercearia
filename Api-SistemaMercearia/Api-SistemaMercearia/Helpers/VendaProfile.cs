using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models;
using AutoMapper;

namespace Api_SistemaMercearia.Helpers
{
	public class VendaProfile : Profile
	{
        public VendaProfile()
        {
            CreateMap<Venda,VendaDTO>().ReverseMap();
        }
    }
}
