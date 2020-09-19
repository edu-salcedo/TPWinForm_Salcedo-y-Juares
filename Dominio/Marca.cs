using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int id;

        public string nombre{ get; set; }

        public Marca (int Id, string desc)
        {
            id = Id;

            nombre = desc;
        }
        
        public Marca() { }

        public override string ToString()
        {
            return nombre; 
        }
    }
}
