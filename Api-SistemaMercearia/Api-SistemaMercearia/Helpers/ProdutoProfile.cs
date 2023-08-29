using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models;
using AutoMapper;

namespace Api_SistemaMercearia.Helpers
{
	public class ProdutoProfile : Profile
	{
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
