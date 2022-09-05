using System;
using System.Collections.Generic;
using System.Text;
using Confitec.Dominio;
using MediatR;

namespace Confitec.Recursos.Consultas.Usuarios.ListUsuarios
{
    public class ParametroListUsuarios : IRequest<IEnumerable<Usuario>>
    {
    }
}
