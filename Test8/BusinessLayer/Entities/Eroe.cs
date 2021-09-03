using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Eroe
    { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public categoria Categoria { get; set; }
        public int IdArma { get; set; }
        public enum categoria
        {
            Guerriero, 
            Mago
        }
    }
}
