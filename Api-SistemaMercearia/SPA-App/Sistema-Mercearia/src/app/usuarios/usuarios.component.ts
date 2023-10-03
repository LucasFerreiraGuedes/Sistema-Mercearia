import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Usuario } from '../Models/Usuario';
import { UsuarioServiceService } from '../services/UsuarioService.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  public usuarios$ = new Observable<Usuario[]>();
  public usuarioSelecionado !: Usuario | null;

  constructor(private usuarioService: UsuarioServiceService) { 
   

  }
  
  ngOnInit() {
    this.usuarios$ = this.usuarioService.getAll();
}

selecionarUsuario(usuario: Usuario){
   this.usuarioSelecionado = usuario;
  
}
limparUsuarioSelecionado(){
  this.usuarioSelecionado = null;
}

novoUsuario(){
  this.usuarioSelecionado = new Usuario();

}

submit(usuario : Usuario){
   if(usuario.id == undefined){
    this.usuarioService.post(usuario).subscribe(() => this.ngOnInit());
   }
   else{
    this.usuarioService.put(usuario).subscribe(() => this.ngOnInit());
   }

}

apagarUsuario(id : number){
  this.usuarioService.delete(id).subscribe(() => this.ngOnInit());
}

}
