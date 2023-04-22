using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.DTOs
{
    public class CompromissoDto
    {
        public DateTime Data { get; set; }
        public string Texto { get; set; }
        public int IdUsuario { get; set; }
    }
}
