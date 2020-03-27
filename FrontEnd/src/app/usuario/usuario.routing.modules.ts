import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { UsuarioFormularioComponent } from './usuario-formulario/usuario-formulario.component';

const routes: Routes = [
    { path: '', component: UsuarioListaComponent },
    { path: 'adicionar', component: UsuarioFormularioComponent },
    { path: ':id/editar', component: UsuarioFormularioComponent }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UsuarioRoutingModule { }
