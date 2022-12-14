using Confitec.Data.EF;
using Confitec.Dominio;
using Confitec.Recursos.Consultas.Usuarios.ListUsuarios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Recursos.Consultas.Usuarios
{
    public class ConsultaListUsuarios : IRequestHandler<ParametroListUsuarios, IEnumerable<Usuario>>
    {
        private readonly ConfitecContext _context;

        public ConsultaListUsuarios(ConfitecContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> Handle(ParametroListUsuarios request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
