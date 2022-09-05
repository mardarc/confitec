using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confitec.Data.EF;
using Confitec.Dominio;
using MediatR;

namespace Confitec.Recursos.Comandos.Usuarios
{
    public class ComandoCreateUsuario :  IRequestHandler<ParametroCreateUsuario, Usuario>
    {
        private readonly ConfitecContext _context;
        public ComandoCreateUsuario(ConfitecContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(ParametroCreateUsuario request, CancellationToken cancellationToken)
        {
            var novoUsuario = new Usuario()
            {
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Escolaridade = request.Escolaridade
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario;
        }
    }
}
