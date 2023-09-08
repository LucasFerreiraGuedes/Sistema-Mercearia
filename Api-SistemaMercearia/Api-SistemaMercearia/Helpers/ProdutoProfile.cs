using Api_SistemaMercearia.DTO_s;
using Api_SistemaMercearia.Models.Products;
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
