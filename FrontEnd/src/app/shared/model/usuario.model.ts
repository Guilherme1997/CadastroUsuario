import { Sexo } from './sexo.model';

export class Usuario {
    UsuarioID: number;
    Nome: string;
    DataNascimento: string;
    Email: string;
    Sexo: Sexo;
    Ativo: boolean;
}
