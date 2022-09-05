using Confitec.Dominio;
using Confitec.Dominio.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ParametroCreateUsuario : IRequest<Usuario>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
