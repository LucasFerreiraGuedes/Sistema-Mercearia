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
  constructor(private produtoService : ProdutoService) { }

  ngOnInit() {
    this.produtos$ = this.produtoService.getAll();
  }

}
