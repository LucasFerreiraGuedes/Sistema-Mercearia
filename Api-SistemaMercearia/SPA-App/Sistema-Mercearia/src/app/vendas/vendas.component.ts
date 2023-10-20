import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../Models/Produto';
import { ProdutoService } from '../services/ProdutoService';
import { CarrinhoDeCompra } from '../Models/Carrinho';
import { ProdutoCarrinho } from '../Models/ProdutoCarrinho';

@Component({
  selector: 'app-vendas',
  templateUrl: './vendas.component.html',
  styleUrls: ['./vendas.component.css']
})
export class VendasComponent implements OnInit {
 
  public produtos$ = new Observable<Produto[]>();

  public produtoSelecionado! : Produto | null;
  public carrinhoDeCompras = new CarrinhoDeCompra();
  public quantidadeVendida : number = 1;

  constructor(private produtoService: ProdutoService) { 
    
  }

  ngOnInit() {
    this.produtos$ = this.produtoService.getAll();
  }

  selecionarProduto(produto: Produto){
      this.produtoSelecionado = produto;
     
  }

  limparProdutoSelecionado(){
    this.produtoSelecionado = null;
  }

  adicionarAoCarrinho(){
    
   var produto = new ProdutoCarrinho(this.produtoSelecionado!, this.quantidadeVendida);
   
    this.carrinhoDeCompras.Produtos.push(produto);

    this.carrinhoDeCompras.CalculaValorCompra();
    console.log(this.carrinhoDeCompras.Produtos);
    console.log(this.carrinhoDeCompras.ValorTotal);

    this.limparProdutoSelecionado();

  }

 

}
