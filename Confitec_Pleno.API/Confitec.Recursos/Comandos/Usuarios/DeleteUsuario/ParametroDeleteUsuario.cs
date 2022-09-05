using System;
using System.Collections.Generic;
using System.Text;
using Confitec.Dominio;
using MediatR;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ParametroDeleteUsuario : IRequest<Usuario>
    {
        public int Id { get; set; }
    }
}
