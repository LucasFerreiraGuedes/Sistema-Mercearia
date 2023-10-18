import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../Models/Produto';
import { ProdutoService } from '../services/ProdutoService';

@Component({
  selector: 'app-vendas',
  templateUrl: './vendas.component.html',
  styleUrls: ['./vendas.component.css']
})
export class VendasComponent implements OnInit {
 
  public produtos$ = new Observable<Produto[]>();

  public produtoSelecionado! : Produto | null;

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.produtos$ = this.produtoService.getAll();
  }

  selecionarProduto(produto: Produto){
      this.produtoSelecionado = produto;
  }

  limparProdutoSelecionado(){
    this.produtoSelecionado = null;
  }

}
