import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Produto } from '../Models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

constructor(private Htpp: HttpClient) { }

baseUrl = `${environment.baseUrlApi}/Produto`;

getAll(){
   return this.Htpp.get<Produto[]>(this.baseUrl);
}

}
