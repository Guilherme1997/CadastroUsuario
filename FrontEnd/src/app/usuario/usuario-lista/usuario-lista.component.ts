import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../shared/model/usuario.model';
import { UsuarioService } from 'src/app/shared/service/usuario-service';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.css']
})
export class UsuarioListaComponent implements OnInit {

  public usuarios: Usuario[];

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.listar();
  }

  public filtrar(dadosDePesquisa: Usuario) {

    if (dadosDePesquisa.Ativo == null) {
      dadosDePesquisa.Ativo = false;
    }

    if (dadosDePesquisa.Nome == "") {
      dadosDePesquisa.Nome = null;
    }

    this.usuarioService.filtrar(dadosDePesquisa.Nome, dadosDePesquisa.Ativo).subscribe(
      response => {
        this.usuarios = response;
      }
    );
  }

  public deletarUsuario(usuario: Usuario) {
    const confirmar = confirm("Deseja realmente deletar esta categoria?");
    if (confirmar === true) {
      this.usuarioService.deletar(usuario.UsuarioID).subscribe(
        () => {
          this.usuarios = this.usuarios.filter(x => x.UsuarioID != usuario.UsuarioID)
        }
      );
    }
    return
  }

  public listar() {

    this.usuarioService.listar().subscribe(
      response => {
        this.usuarios = response
      }
    )
  }

}
