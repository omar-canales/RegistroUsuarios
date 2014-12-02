using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity.EntRegistro
{
    public class EntColonia
    {
        public EntColonia() { }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDelegacion { get; set; }
    }
}
