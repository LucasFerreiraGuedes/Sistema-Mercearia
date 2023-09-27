import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,concatMap, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Usuario } from '../Models/Usuario';

@Injectable({
    providedIn : 'root'
})
export class UsuarioServiceService {

constructor(private http: HttpClient) { }

baseUrl = `${environment.baseUrlApi}/Usuario`;

  getAll(){

    return this.http.get<Usuario[]>(`${this.baseUrl}/AllUsers`)

}

}