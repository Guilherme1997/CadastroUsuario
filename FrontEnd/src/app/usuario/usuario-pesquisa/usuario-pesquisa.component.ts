import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Usuario } from '../../shared/model/usuario.model';
import { UsuarioService } from 'src/app/shared/service/usuario-service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-usuario-pesquisa',
  templateUrl: './usuario-pesquisa.component.html',
  styleUrls: ['./usuario-pesquisa.component.css']
})
export class UsuarioPesquisaComponent implements OnInit {

  public formularioDePesquisa: FormGroup;

  @Output() dadosDaPesquisa = new EventEmitter();


  constructor(
    private contatoService: UsuarioService,
    private formBuildr: FormBuilder
  ) { }

  ngOnInit() {
    this.contruirFormularioDePesquisa();

  }

  enviarDadosDePesquisa() {
    this.dadosDaPesquisa.emit(this.formularioDePesquisa.value);
  }

  public contruirFormularioDePesquisa() {
    this.formularioDePesquisa = this.formBuildr.group({
      Nome: [null],
      Ativo: [null],
    })
  }

  public submitForm() {
    alert(this.formularioDePesquisa.value);
  }

}
