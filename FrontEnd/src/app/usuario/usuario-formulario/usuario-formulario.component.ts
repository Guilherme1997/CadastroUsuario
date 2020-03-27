import { Component, OnInit, ɵConsole } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';

import { Usuario } from '../../shared/model/usuario.model';

import * as moment from 'moment';

import { validarData } from '../../shared/lib/data';

import { switchMap } from 'rxjs/operators';

import { UsuarioService } from 'src/app/shared/service/usuario-service';

import { Sexo } from 'src/app/shared/model/sexo.model';

import { SexoService } from 'src/app/shared/service/sexo-service';

@Component({
  selector: 'app-usuario-formulario',
  templateUrl: './usuario-formulario.component.html',
  styleUrls: ['./usuario-formulario.component.css']
})
export class UsuarioFormularioComponent implements OnInit {
  public acaoFormulario: string;
  public usuarioFormulario: FormGroup;
  public titulo: string;
  private usuario: Usuario = new Usuario();

  private parametroUrl = this.activatedRoute.snapshot.url[0].path;
  private sexos: Sexo[];
  public itemFormularioCadastro: boolean;
  constructor(
    private usuarioService: UsuarioService,
    private activatedRoute: ActivatedRoute,
    private formBuildr: FormBuilder,
    private router: Router,
    private sexoService: SexoService
  ) { }

  ngOnInit() {
    this.atribuirAcaoAoFormulario();
    this.contruirFormularioUsuario();
    this.obterSexo();
    this.carregarusuarios();
  }

  private atribuirTiTulo(titulo: string): void {
    this.titulo = titulo;
  }

  private atribuirAcaoAoFormulario(): void {
    let titulo;
    if (this.parametroUrl == 'adicionar') {
      this.itemFormularioCadastro = true;
      this.acaoFormulario = 'Adicionar';
      titulo = 'Cadastrar Usuário';
      this.atribuirTiTulo(titulo);
      return;
    }
    this.acaoFormulario = 'Editar';
    this.itemFormularioCadastro = false;

    titulo = 'Editar Usuário';
    this.atribuirTiTulo(titulo);
  }

  public deletar() {
    const confirmar = confirm("Deseja realmente deletar esta categoria?");
    if (confirmar == true) {
      this.activatedRoute.paramMap.pipe(
        switchMap(params => this.usuarioService.deletar(+ params.get('id')))
      ).subscribe(
        () => {
          this.redirecionarPagina()
        })
    }
    return;
  }

  public redirecionarPagina() {
    this.router.navigateByUrl('/usuario');
  }

  submitForm() {

    if (validarData(this.usuarioFormulario.controls['DataNascimento'].value)) {
      alert("Data Inválida")
      return
    }
    if (this.acaoFormulario == 'Adicionar') {
      var dataFormatada = moment(this.usuarioFormulario.controls['DataNascimento'].value, "DD-MM-YYYY").format("L");
      this.usuarioFormulario.controls['DataNascimento'].setValue(dataFormatada);
      this.usuarioService.criar(this.usuarioFormulario.value).subscribe();
      alert('usuario salvo com sucesso!');
      this.redirecionarPagina()
      return;
    }

    this.usuarioService.atualizar(this.usuarioFormulario.value, parseInt(this.parametroUrl)).subscribe();
    alert('usuario alterado com sucesso!');
    this.redirecionarPagina();

  }

  public obterSexo() {
    this.sexoService.obter().subscribe(response => {
      this.sexos = response;
    })
  }



  private contruirFormularioUsuario() {
    this.usuarioFormulario = this.formBuildr.group({
      Nome: [null, [Validators.required, Validators.minLength(3)]],
      DataNascimento: [null, Validators.required],
      Email: [null, [Validators.required, Validators.email]],
      Senha: [null, Validators.required],
      SexoID: [null, Validators.required],
      Ativo: ['']

    })
  }

  private carregarusuarios() {
    if (this.acaoFormulario == 'Editar') {
      this.activatedRoute.paramMap.pipe(
        switchMap(params => this.usuarioService.obterPorId(+ params.get('id')))
      ).subscribe(
        (usuario) => {
          this.usuario = usuario
          var data = moment(this.usuario.DataNascimento).format('DD-MM-YYYY HH:mm:ss');
          this.usuario.DataNascimento = data;
          this.usuarioFormulario.patchValue(this.usuario)
        },
        (error) => alert('Ocorreu um erro no servidor, tente mais tarde')
      )
    }
  }


}
