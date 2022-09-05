## CONFITEC - TESTE TÉCNICO

Este é um projeto desenvolvido com o fim de ser apresentado no processo seletivo para contratação de Desenvolvedor Full Stack.
O Projeto consiste em um sistema de gerenciamento de usuários. Este sistema é um sistema web desenvolvido em duas partes (front-end e back-end).
Para desenvolvimento do sistemas foram escolhidos o Angular 13 para desenvolvimento do front-end e .Net 5 e .Net Core 3.1 para desenvolvimento do back-end.
O desenvolvimento do front-end foi feito a partir de um tema devidamente criado, o tema e sua documentação podem ser encontrados em **[Light Bootstrap Dashboard Angular](https://demos.creative-tim.com/light-bootstrap-dashboard-angular2/dashboard)**

### Pré-requisitos
Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [Node.js](https://nodejs.org/en/), [.NET](https://dotnet.microsoft.com/en-us/download)
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/) e [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)

### 🎲 Rodando o Front End

```bash
# Clone este repositório
$ git clone <https://github.com/tgmarinho/nlw1>

# Acesse a pasta do projeto no terminal/cmd
$ cd Confitec

# Vá para a pasta server
$ cd Confitec_Pleno.API

# Instale o angular
$ npm install -g @angular/cli

# Instale as dependências
$ npm install

## Altere o endereço da API (back end). Vá até o arquivo src/environments/environment.ts e altere a variável apiUrl

# Execute a aplicação em modo de desenvolvimento
$ ng serve

# O servidor inciará na porta:4200 - acesse <http://localhost:4200/>
```

### 🎲 Rodando o Back End

```bash
# Abra a solution do projeto na Confitec_Pleno.API
$ Confitec_Pleno.sln

# Altere o arquivo de configuração, appsetting.json presente no projeto da API.
$ "ConfitecConnection": "Data Source=****\\sqlexpress;Initial Catalog=CONFITEC_PLENO;Integrated Security=False;User ID=****;Password=***;"

# Compile o projeto
$ A compilação do projeto pode ocorrer clicando no item do menu compilação->compilar solução ou executando o comando "dotnet build" na pasta do projeto.

# Executando o projeto
$ Para executar o projeto clique no item do menu depurar->iniciar depuracao (confirme que o projeto selecionado para inicialização é o Confitec_Pleno) ou executando o comando "dotnet run" na pasta do projeto.
```

