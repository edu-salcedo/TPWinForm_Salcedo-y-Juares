using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int id;
        public string nombre{ get; set; }

        public Categoria() { }

        public Categoria(int Id, string Descripcion)
        {
            id = Id;
            nombre = Descripcion;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
