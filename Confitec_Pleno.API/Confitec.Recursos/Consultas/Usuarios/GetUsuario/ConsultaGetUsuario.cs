using Confitec.Data.EF;
using Confitec.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Recursos.Consultas.Usuarios
{
    public class ConsultaGetUsuario : IRequestHandler<ParametroGetUsuario, Usuario>
    {
        private readonly ConfitecContext _context;
        public ConsultaGetUsuario(ConfitecContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Handle(ParametroGetUsuario request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
