using Api_SistemaMercearia.Models;
using Api_SistemaMercearia.Models.Products;
using Api_SistemaMercearia.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaMercearia.Context

{
    public class ContextDb : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Venda> Vendas { get; set; }
		public DbSet<ProdutoVenda> ProdutosVendas { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options): base (options)
        {
            
        }
    }
}
