using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntBitacora
    {
        public string Ingreso { get; set; }
        public string Salida { get; set; }
        public int BitacoraID { get; set; }
        public EntAccount Cuenta { get; set; }
    }
}
