﻿using Api_SistemaMercearia.Models.Products;

namespace Api_SistemaMercearia.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataDaVenda { get; set; }
        public IEnumerable<ProdutoVenda>? ProdutosVendidos { get; set; }

        public Venda(DateTime dataDaVenda,double valorTotal)
        {
            DataDaVenda = DateTime.Now;
            this.ValorTotal = valorTotal;
        }
    }
}
