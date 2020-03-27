import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario.routing.modules';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UsuarioFormularioComponent } from './usuario-formulario/usuario-formulario.component';
import { NgxMaskModule } from 'ngx-mask';
import { UsuarioPesquisaComponent } from './usuario-pesquisa/usuario-pesquisa.component';

@NgModule({
    declarations: [
        UsuarioListaComponent,
        UsuarioFormularioComponent,
        UsuarioPesquisaComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        UsuarioRoutingModule,
        NgxMaskModule.forRoot()

    ]
})
export class UsuarioModule { }
