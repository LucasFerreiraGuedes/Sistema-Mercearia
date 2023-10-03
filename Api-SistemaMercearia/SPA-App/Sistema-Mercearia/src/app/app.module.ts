import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import {HttpClientModule} from '@angular/common/http'
import { UsuarioServiceService } from './services/UsuarioService.service';
import { FormsModule } from '@angular/forms';
import { EstoqueComponent } from './estoque/estoque.component';
import { ProdutoService } from './services/ProdutoService';

@NgModule({
  declarations: [				
    AppComponent,
      NavComponent,
      UsuariosComponent,
      EstoqueComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    HttpClientModule,
    FormsModule
  ],
  providers: [UsuarioServiceService,ProdutoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
