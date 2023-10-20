import { Produto } from "./Produto";

export class ProdutoCarrinho extends Produto {
    
    public quantidadeVendida : number = 0;

    constructor(produto : Produto, quantidadeVendida : number) {
        super()
       this.descricao = produto.descricao;
       this.estoque = produto.estoque;
       this.id = produto.id;
       this.marca = produto.marca;
       this.valor = produto.valor;

       this.quantidadeVendida = quantidadeVendida;
    }

}
