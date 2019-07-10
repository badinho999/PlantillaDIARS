using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntAccountHashTable
    {
        public EntHashtable Hashtable { get; set; }
        public EntAccount Cuenta { get; set; }
        public bool Activa { get; set; }

        //No necesario
        public int ID { get; set; }
    }
}
