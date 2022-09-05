using Confitec.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Dominio.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
