using Api_SistemaMercearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaMercearia.Context

{
	public class ContextDb : DbContext
	{
		DbSet<Produto> Produtos { get; set; }
		DbSet<Venda> Vendas { get; set; }
		DbSet<ProdutoVenda> ProdutosVendas { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options): base (options)
        {
            
        }
    }
}
