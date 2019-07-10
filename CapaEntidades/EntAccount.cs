using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntAccount
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Fechacreacion { get; set; }

        [StringLength(9,ErrorMessage ="Este campo debe contener 9 caracteres")]
        public string Telefono { get; set; }

        public string NombreUsuario { get; set; }
        public EntCliente Cliente { get; set; }
    }
}
