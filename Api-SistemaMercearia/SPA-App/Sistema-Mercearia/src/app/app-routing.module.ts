import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { EstoqueComponent } from './estoque/estoque.component';


const routes: Routes = [
  {path : 'usuarios',component: UsuariosComponent},
  {path : 'estoque',component: EstoqueComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
