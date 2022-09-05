import { Escolaridade } from "../enum/escolaridade";

export class Usuario {
    id: number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento: Date;
    escolaridade: Escolaridade;
}