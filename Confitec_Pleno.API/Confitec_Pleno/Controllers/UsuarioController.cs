using Confitec.Data.EF;
using Confitec.Dominio;
using Confitec.Recursos.Comandos.Usuarios;
using Confitec.Recursos.Consultas;
using Confitec.Recursos.Consultas.Usuarios.ListUsuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec_Pleno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(ConfitecContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var command = new ParametroListUsuarios();
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Selecionar/{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var command = new ParametroGetUsuario { Id = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Novo")]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] ParametroCreateUsuario command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<Usuario>> UpdateUsuario([FromBody] ParametroUpdateUsuario command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar/{id:int}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            {
                var command = new ParametroDeleteUsuario { Id = id };
                var usuario = await _mediator.Send(command);

                var response = new
                {
                    sucesso = true
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
