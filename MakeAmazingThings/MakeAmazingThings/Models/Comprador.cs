using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeAmazingThings.Models
{
    public class Comprador
    {
        //construtor
        public Comprador()
        {
            ListaDeFaturas = new HashSet<Compra>();

        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        public int Telemovel { get; set; }

        public string CodPostal { get; set; }

        public int NIF { get; set; } 
        
        public virtual ICollection<Compra> ListaDeFaturas { get; set; }
    }
}