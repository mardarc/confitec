using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confitec.Data.EF;
using Confitec.Dominio;
using MediatR;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ComandoUpdateUsuario : IRequestHandler<ParametroUpdateUsuario, Usuario>
    {
        private readonly ConfitecContext _context;
        public ComandoUpdateUsuario(ConfitecContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(ParametroUpdateUsuario request, CancellationToken cancellationToken)
        {
            var usuario = _context.Usuarios.Where(a => a.Id == request.Id).FirstOrDefault();
            if (usuario == null)
            {
                return default;
            }
            else
            {
                usuario.Nome = request.Nome;
                usuario.Sobrenome = request.Sobrenome;
                usuario.Email = request.Email;
                usuario.DataNascimento = request.DataNascimento;
                usuario.Escolaridade = request.Escolaridade;
            };

            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
