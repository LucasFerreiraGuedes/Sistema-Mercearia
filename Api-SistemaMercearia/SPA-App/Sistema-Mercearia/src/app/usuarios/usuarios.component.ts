import { Component, OnInit } from '@angular/core';
import { Usuario } from '../Models/Usuario';
import { UsuarioServiceService } from '../services/UsuarioService.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor(private usuarioService: UsuarioServiceService) { }


  public user = new Usuario(1,'lucas','guedesl@','1234','MG','96');
  public userr = new Usuario(1,'lucas','guedesl@','1234','MG','96');



public usuarios : Usuario[] = [];

public userFake :  Usuario[] = [];

  ngOnInit() {

   this.userFake.push(this.user);

   this.usuarioService.getAll().subscribe(
    (usuario : Usuario[]) => {
      this.usuarios = usuario;
      console.log(this.usuarios)
    },
    (erro: any) => {console.log(erro)}
   )
   
    
  }

}
