import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ResultadoController } from "_models/global/resultado-controller";
import { ResultadoAtualizarUsuario } from "_models/usuario/resultado-atualizar-usuario";
import { Usuario } from "_models/usuario/usuario";
import { UsuarioDTO } from "_models/usuario/usuario-dto";
import { BaseControllerService } from "./base-controller.service";

@Injectable({
    providedIn: 'root'
})
export class UsuarioControllerService extends BaseControllerService {
    constructor(_http: HttpClient) {
        super(_http);
    }

    public listarUsuarios(): Observable<Array<UsuarioDTO>> {
        return this.get<Array<UsuarioDTO>>(`Usuario/Listar`);
    }
    
    public selecionarUsuario(id : number): Observable<UsuarioDTO> {
        return this.get<UsuarioDTO>(`Usuario/Selecionar/${id}`);
    }

    public atualizarUsuario(usuario: UsuarioDTO) : Observable<ResultadoAtualizarUsuario> {
        return this.put<ResultadoAtualizarUsuario, UsuarioDTO>(`Usuario/Atualizar`, usuario);
    }

    public novoUsuario(usuario: UsuarioDTO) : Observable<Usuario> {
        return this.post<Usuario, UsuarioDTO>(`Usuario/Novo`, usuario);
    }

    public deletarUsuario(id : number) : Observable<ResultadoController> {
        return this.delete<ResultadoController>(`Usuario/Deletar/${id}`);
    }
}