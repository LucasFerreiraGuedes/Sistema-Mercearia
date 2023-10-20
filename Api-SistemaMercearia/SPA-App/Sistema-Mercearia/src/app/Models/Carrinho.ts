
import { ProdutoCarrinho } from "./ProdutoCarrinho";

export class CarrinhoDeCompra {
    
  Produtos : ProdutoCarrinho[] = [];
  ValorTotal : number = 0;


   CalculaValorCompra() {
    this.ValorTotal = 0;
      
    this.Produtos.forEach(x => {
        this.ValorTotal += x.valor! * x.quantidadeVendida;
    })

   }
}
