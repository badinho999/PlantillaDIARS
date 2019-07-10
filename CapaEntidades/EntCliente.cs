using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntCliente
    {
        [Required]
        [StringLength(80)]
        public string ApellidosCliente { get; set; }

        public string FechaNacimiento { get; set; }

        [Required]
        [StringLength(90)]
        public string NombreCliente { get; set; }

        public bool Sexo { get; set; }
        public string Dni { get; set; }
    }
}
