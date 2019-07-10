using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaEntidades
{
    public class EntAccountViewData
    {
        public EntAccount account { get; set; }
        public EntPasswordAccount PasswordAccount { get; set; }
        public bool Success { get; set; }
    }
}
