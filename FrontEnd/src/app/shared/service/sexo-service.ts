import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Sexo } from '../model/sexo.model';

@Injectable({
    providedIn: 'root'
})
export class SexoService {

    constructor(private http: HttpClient) { }

    private porta = '44382';
    private path = 'api/sexo';
    private url = `https://localhost:${this.porta}/${this.path}`;


    obter(): Observable<Sexo[]> {
        const url = `${this.url}`;
        return this.http.get(url).pipe(
            catchError(this.descreverErro),
            map(this.obterSexos)
        )
    }

    private obterSexos(jsonData: any[]): Sexo[] {
        const sexo: Sexo[] = [];
        jsonData.forEach(element => sexo.push(element));
        return sexo;
    }

    private descreverErro(error: any): Observable<any> {
        console.log('ERRO NA REQUISIÇAO -> ', error);
        return throwError(error);
    }

}
