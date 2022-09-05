using Confitec.Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Recursos.Consultas
{
    public class ParametroGetUsuario : IRequest<Usuario>
    {
        public int Id { get; set; }
    }
}
