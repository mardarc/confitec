using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Dominio.DTOs
{
    public abstract class ResultadoController
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
    }
}
