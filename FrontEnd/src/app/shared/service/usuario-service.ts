import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Usuario } from '../model/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  private porta = '44382';
  private path = 'api/usuario';
  private url = `https://localhost:${this.porta}/${this.path}`;


  listar(): Observable<Usuario[]> {
    return this.http.get(this.url).pipe(
      catchError(this.descreverErro),
      map(this.obterUsuarios)
    );
  }

  filtrar(nome: string, flagAtivo: boolean): Observable<Usuario[]> {
    const parametro = "/" + nome + "/" + flagAtivo;
    return this.http.get(this.url + parametro).pipe(
      catchError(this.descreverErro),
      map(this.obterUsuarios)
    );
  }

  obterPorId(id: number): Observable<Usuario> {
    const url = `${this.url}/${id}`;
    return this.http.get(url).pipe(
      catchError(this.descreverErro),
      map(this.converterJsonParaUsuario)
    )
  }

  criar(usuario: Usuario): Observable<Usuario> {
    return this.http.post(this.url, usuario).pipe(
      catchError(this.descreverErro),
      map(this.converterJsonParaUsuario)
    );
  }

  atualizar(usuario: Usuario, id: number): Observable<Usuario> {
    const url = `${this.url}/${id}`;
    console.log(url);
    return this.http.put(url, usuario).pipe(
      catchError(this.descreverErro),
      map(() => usuario)
    );
  }

  deletar(id: number): Observable<Usuario> {
    const url = `${this.url}/${id}`;
    return this.http.delete(url).pipe(
      catchError(this.descreverErro),
      map(() => null)
    );
  }

  private obterUsuarios(jsonData: any[]): Usuario[] {
    const usuario: Usuario[] = [];
    jsonData.forEach(element => usuario.push(element));
    return usuario;
  }

  private converterJsonParaUsuario(jsonData: any): Usuario {
    return jsonData as Usuario;
  }

  private descreverErro(error: any): Observable<any> {
    console.log('ERRO NA REQUISIÇAO -> ', error);
    return throwError(error);
  }

}
