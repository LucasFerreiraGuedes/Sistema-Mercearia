import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Produto } from '../Models/Produto';
import { Usuario } from '../Models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

constructor(private Htpp: HttpClient) { }

baseUrl = `${environment.baseUrlApi}/Produto`;

getAll(){
   return this.Htpp.get<Produto[]>(this.baseUrl);
}

putProduto(produto : Produto){
  return this.Htpp.put<Produto>(`${this.baseUrl}/${produto.id}`, produto)
}

post(produto : Produto){
  return this.Htpp.post<Usuario>(this.baseUrl,produto);
}

delete(id : number){
  return this.Htpp.delete<void>(`${this.baseUrl}/${id}`)
}

}
