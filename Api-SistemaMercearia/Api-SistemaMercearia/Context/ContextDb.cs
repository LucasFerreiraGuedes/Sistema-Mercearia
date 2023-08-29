using Api_SistemaMercearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaMercearia.Context

{
	public class ContextDb : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Venda> Vendas { get; set; }
		public DbSet<ProdutoVenda> ProdutosVendas { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options): base (options)
        {
            
        }
    }
}
