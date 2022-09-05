using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confitec.Data.EF;
using Confitec.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ComandoDeleteUsuario : IRequestHandler<ParametroDeleteUsuario, Usuario>
    {
        private readonly ConfitecContext _context;
        public ComandoDeleteUsuario(ConfitecContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(ParametroDeleteUsuario request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FindAsync(request.Id);
            if (usuario != null)
            {
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return usuario;
        }
    }
}
