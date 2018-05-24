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

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Telemóvel")]
        public int Telemovel { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public int NIF { get; set; } 
        
        public virtual ICollection<Compra> ListaDeFaturas { get; set; }
    }
}