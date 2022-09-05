import { Escolaridade } from "../enum/escolaridade";

export class UsuarioDTO {
    id: number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento: Date;
    escolaridade: Escolaridade;
}