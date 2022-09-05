using System;
using System.Collections.Generic;
using System.Text;
using Confitec.Dominio;
using Confitec.Dominio.Enum;
using MediatR;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ParametroUpdateUsuario : IRequest<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
