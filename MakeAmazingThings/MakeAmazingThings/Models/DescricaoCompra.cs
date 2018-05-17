using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeAmazingThings.Models
{
    public class DescricaoCompra
    {
        [Key]
        public int ID { get; set; }

        public decimal PrecoVenda { get; set; }

        public int Quantidade { get; set; }

        public decimal IVA { get; set; }

        [ForeignKey ("Produto")]
        public int ProdutoFk { get; set; }
        public virtual Produtos Produto { get; set; }

        [ForeignKey("Compra")]
        public int CompraFk { get; set; }
        public virtual Compra Compra { get; set; }
    }
}