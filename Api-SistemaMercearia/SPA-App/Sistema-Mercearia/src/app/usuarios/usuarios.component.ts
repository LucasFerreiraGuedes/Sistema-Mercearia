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

  public usuarios$;

  constructor(private usuarioService: UsuarioServiceService) { 
   this.usuarios$ = this.usuarioService.getAll();

  }
  
  ngOnInit() {

}
}
