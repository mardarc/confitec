import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { UsuarioDTO } from '_models/usuario/usuario-dto';
import { UsuarioControllerService } from '_services/controllers/usuario-controller.service';
import { Escolaridade } from '_models/enum/escolaridade';

declare const $: any;
declare interface EscolaridadeInfo {
    id: number;
    descricao: string;
}

declare interface UsuariosTableData {
  headerRow: string[];
  dataRows: UsuarioDTO[];
}

export const ESCOLARIDADES: EscolaridadeInfo[] = [
  {id: 0, descricao: 'infantil'},
  {id: 1, descricao: 'fundamental'},
  {id: 2, descricao: 'medio'},
  {id: 3, descricao: 'superior'},
];

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  private _usuarioGerenciado: UsuarioDTO;
  public escolaridadeDados: any[];
  public gerenciarUsuarioForm : FormGroup;
  public usuariosDados: UsuariosTableData;
  public editarUsuario : boolean = false;
  public alertDelete : boolean = false;
  public deleteId : number;

  constructor(
    private _usuarioControllerService: UsuarioControllerService,
    private _formBuilder: FormBuilder,
    private _datePipe: DatePipe
  ) { }

  ngOnInit() {
    this.ListarUsuarios();
    this.criarGerenciarUsuarioForm();
    this.escolaridadeDados = ESCOLARIDADES.filter(escolaridadeDados => escolaridadeDados);
  }

  onSubmit(): void {
    this._usuarioGerenciado = {
      id: this.editarUsuario ? this.gerenciarUsuarioForm.get('idUsuario').value : null,
      nome: this.gerenciarUsuarioForm.get('nome').value,
      sobrenome: this.gerenciarUsuarioForm.get('sobrenome').value,
      email: this.gerenciarUsuarioForm.get('email').value,
      escolaridade: this.gerenciarUsuarioForm.get('escolaridade').value,
      dataNascimento: this.gerenciarUsuarioForm.get('dataNascimento').value
    };
    if (this.gerenciarUsuarioForm.invalid) {
      this.showNotification("Não foi possível processar a solicitação. Verifique se todos os campos estão preenchidos", "pe-7s-users", 'danger');
      return;
    }
    this.editarUsuario ? this.AtualizarUsuario(this._usuarioGerenciado) : this.AdicionarUsuario(this._usuarioGerenciado);

    this.gerenciarUsuarioForm.reset();
  }

  public criarGerenciarUsuarioForm() : void {
    this.gerenciarUsuarioForm = this._formBuilder.group({
      idUsuario: [null],
      nome: [null, [Validators.required, Validators.maxLength(100)]],
      sobrenome: [null, [Validators.required, Validators.maxLength(100)]],
      email: [null, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$"), Validators.maxLength(100)]],
      dataNascimento: [null, [Validators.required]],
      escolaridade: [null, [Validators.required]]
    });
  }
  public ListarUsuarios() : void{
    this.usuariosDados = {
      headerRow: ['Nome', 'Sobrenome', 'E-mail', 'Data de Nascimento'],
      dataRows: []
    };
    let usuario: any[];
    this._usuarioControllerService.listarUsuarios().subscribe(
      (value) => value.forEach(element => {
          this.usuariosDados.dataRows.push(element);
      }),
      (error) => this.showNotification('Não foi possível listar os usuários.', 'pe-7s-users', 'danger')
    );
  }

  public DeletarUsuario(id : number) : void {
    if(this.alertDelete){
      this._usuarioControllerService.deletarUsuario(id).subscribe(
        (result) => {
          if (result.sucesso) {
            this.showNotification("O usuário foi devidamente excluído do sistema.", "pe-7s-close", 'info')
            this.ListarUsuarios();
          }
          else {
            this.showNotification("Não foi possível excluir o usuário." + result.mensagemErro, "pe-7s-close", 'danger')
          }
        },
        (error) => {
          this.showNotification("Não foi possível excluir o usuário." + error, "pe-7s-close", 'danger')
        }
      );
      this.alertDelete = false;
      this.deleteId = id;
    } else { 
      this.alertDelete = true;
      this.deleteId = id;
    }
  }

  public AtualizarUsuario(usuario : UsuarioDTO) : void {
    if (this._validarDataNascimento(usuario.dataNascimento)){
      this._usuarioControllerService.atualizarUsuario(usuario).subscribe(
        (result) => {
            this.showNotification("Usuário alterado com sucesso!", "pe-7s-smile", 'info' )
            this.ListarUsuarios();
        }, (error) => this.showNotification("Não foi possível atualizar usuário", "pe-7s-smile", 'danger')
      )
    } else {
      this.showNotification("Não foi possível atualizar usuário. Verifique a data de nascimento", "pe-7s-smile", 'danger')
    }
  }

  public AdicionarUsuario(usuario : UsuarioDTO) : void {
    if (this._validarDataNascimento(usuario.dataNascimento)){
      this._usuarioControllerService.novoUsuario(usuario).subscribe(
        (result) => {
          this.showNotification("Usuário adicionado com sucesso!", "pe-7s-smile", 'info' );
          this.ListarUsuarios();
        }, (error) => this.showNotification("Não foi possível adicionar o usuário.", "pe-7s-close", 'danger')
      )
    } else {
      this.showNotification("Não foi possível atualizar usuário. Verifique a data de nascimento", "pe-7s-smile", 'danger')
    }
  }

  public EditarUsuario(row : UsuarioDTO) : void {
    this.editarUsuario = true;
    this.gerenciarUsuarioForm.get('idUsuario').setValue(row.id);
    this.gerenciarUsuarioForm.get('nome').setValue(row.nome);
    this.gerenciarUsuarioForm.get('sobrenome').setValue(row.sobrenome);
    this.gerenciarUsuarioForm.get('email').setValue(row.email);
    this.gerenciarUsuarioForm.get('escolaridade').setValue(row.escolaridade);
    this.gerenciarUsuarioForm.get('dataNascimento').setValue(this._datePipe.transform(row.dataNascimento, 'yyyy-MM-dd')); 
  }

  public CancelarAtualizacao() : void {
    this.editarUsuario = false;
    this.gerenciarUsuarioForm.reset();
  }

  private _validarDataNascimento(dataNascimento : Date) : boolean {
    return new Date(dataNascimento) <= new Date() ? true : false;
  }

  showNotification(message : string, icon : string, style : string){
    $.notify({
        icon: icon,
        message: message
    },{
        type: style,
        timer: 1000,
        placement: {
            from: 'top',
            align: 'right'
        }
    });
  }

  EscolaridadeString(idEscolaridade: Escolaridade) : string {
    switch(idEscolaridade){
      case Escolaridade.infantil: return 'Infantil';
      case Escolaridade.fundamental : return 'Fundamental';
      case Escolaridade.medio : return 'Medio';
      case Escolaridade.superior : return 'Superior';
    }
  }
}
