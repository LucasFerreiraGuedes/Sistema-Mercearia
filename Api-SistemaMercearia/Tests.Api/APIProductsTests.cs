using Api_SistemaMercearia.Controllers;
using Api_SistemaMercearia.Repository.ProdutoRepo;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Api
{
    public class APIProductsTests
    {
        private ProdutoController produtoController;

        public APIProductsTests()
        {
            produtoController = new ProdutoController(new Mock<IProdutoRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void DeleteFromIdInvalid()
        {
            //Teste realizado para assegurar o lançamento de exceção caso o ID do produto não exista no banco de dados
            Assert.ThrowsAsync<Exception>(() => produtoController.DeleteProduct(id: -35));
        }

		[Fact]
		public void AddProductNull()
		{
            //Teste realizado para assegurar o lançamento de exceção caso o produto que esteja tentando se adicionar seja nulo
			Assert.ThrowsAsync<Exception>(() => produtoController.Add(productDTO: null));
		}

	}
}
