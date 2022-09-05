using Confitec.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        [StringLength(80, MinimumLength = 4)]
        public string Nome { get; set; }
        [StringLength(80, MinimumLength = 4)]
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
