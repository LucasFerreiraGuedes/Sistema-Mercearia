import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Usuario } from '../Models/Usuario';

@Injectable()
export class UsuarioServiceService {

constructor(private http: HttpClient) { }

baseUrl = `${environment.baseUrlApi}/Usuario`;

getAll() : Observable<Usuario[]>{
 
    return this.http.get<Usuario[]>(`${this.baseUrl}/AllUsers`)
}

}
