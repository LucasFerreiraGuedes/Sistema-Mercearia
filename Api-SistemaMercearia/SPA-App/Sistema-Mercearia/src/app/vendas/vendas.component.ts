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
  public ResumoCarrinho : boolean = false;

  constructor(private produtoService: ProdutoService) { 
    
  }

  ngOnInit() {
    this.produtos$ = this.produtoService.getAll();
  }

  selecionarProduto(produto: Produto){
      this.produtoSelecionado = produto;
      this.ResumoCarrinho = false;
     
  }

  limparProdutoSelecionado(){
    this.produtoSelecionado = null;
  }

  adicionarAoCarrinho(){
    
   var produto = new ProdutoCarrinho(this.produtoSelecionado!, this.quantidadeVendida);

    this.produtoSelecionado!.estoque -= this.quantidadeVendida;

    this.carrinhoDeCompras.AdicionaProduto(produto);
    this.carrinhoDeCompras.CalculaValorCompra();

    this.quantidadeVendida = 1;
    this.limparProdutoSelecionado();
  }
  
  resumoCarrinho(){

    if(this.ResumoCarrinho){
      this.ResumoCarrinho = false;
    }
    this.ResumoCarrinho = true;
  }  

  limparCarrinho(){
    
    this.carrinhoDeCompras.Produtos = [];
    this.carrinhoDeCompras.ValorTotal = 0;

    this.ngOnInit();

  }

}
