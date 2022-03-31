using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento{ get; set;}
        public char sexo { get; set; }
    }
}
