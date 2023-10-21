
import { Produto } from "./Produto";
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

   AdicionaProduto(produto : ProdutoCarrinho){

    console.log(produto)

    let produtoExistente = this.Produtos.find(x => x.id === produto.id);

    if(produtoExistente){
        produtoExistente.quantidadeVendida += produto.quantidadeVendida;
        
    } else {
        this.Produtos.push(produto);
        
    }
  }

  
    
}
