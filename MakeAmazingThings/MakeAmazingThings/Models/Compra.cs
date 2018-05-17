using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeAmazingThings.Models
{
    public class Compra
    {
        public Compra()
        {
            ListaDeCompras = new HashSet<DescricaoCompra>();
        }
        //TER CUIDADO COM A ORDEM DOS ATRIBUTOS, FAZER UMA ORDEM QUE FAÇA SENTIDO PARA DEPOIS SER APRESENTADO
        //NAO POR O NUMFATURA COMO AUTO INCREMENT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumFatura { get; set; }

        public DateTime Data { get; set; }

        public decimal TotalSiva { get; set; }

        public decimal TotalCiva { get; set; }

        [ForeignKey("Comprador")]
        public int CompradorFk { get; set; }
        public virtual Comprador Comprador { get; set; }

        public virtual ICollection<DescricaoCompra> ListaDeCompras{ get; set; }
    }
}
