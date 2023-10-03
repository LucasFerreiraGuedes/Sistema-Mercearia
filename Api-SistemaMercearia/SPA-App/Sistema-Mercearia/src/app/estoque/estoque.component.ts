import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../services/ProdutoService';
import { Observable } from 'rxjs';
import { Produto } from '../Models/Produto';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.css']
})
export class EstoqueComponent implements OnInit {

  public produtos$ = new Observable<Produto[]>();

  public produtoSelecionado !: Produto | null;

  constructor(private produtoService : ProdutoService) { }

  ngOnInit() {
    this.produtos$ = this.produtoService.getAll();
    console.log(this.produtos$)
  }

  selecionarProduto(produto : Produto){
    this.produtoSelecionado = produto;
  }

  limparProdutoSelecionado(){
    this.produtoSelecionado = null;
  }

  novoProduto(){
    this.produtoSelecionado = new Produto();
  }

  submit(produto : Produto){

    if(produto.id != undefined){
      this.produtoService.putProduto(produto).subscribe(() => this.ngOnInit());
    }
    else{
      this.produtoService.post(produto).subscribe(() => this.ngOnInit());
    }
   
    }

  apagarProduto(id : number){
    this.produtoService.delete(id).subscribe(() => this.ngOnInit());
  }

}
