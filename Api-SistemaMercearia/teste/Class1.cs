using Api_SistemaMercearia.Controllers;
using Api_SistemaMercearia.Repository.ProdutoRepo;
using AutoMapper;
using Moq;
using Xunit;

namespace teste
{
	public class Class1
	{
		private ProdutoController produtoController;

		public Class1()
		{
			produtoController = new ProdutoController(new Mock<IProdutoRepository>().Object, new Mock<IMapper>().Object);
		}

		[Fact]
		public void DeleteFromIdInvalid()
		{
			Assert.ThrowsAsync<Exception>(() => produtoController.DeleteProduct(id: -35));
		}
	}
}