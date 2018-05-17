using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakeAmazingThings.Models
{
    public class Fotos
    {
        [Key]
        public int ID{ get; set; }

        public int Ordem { get; set; }

        [Display(Name="Fotografia")]
        public string NomeFoto { get; set; }

        //****************************************************************************
        [ForeignKey("Produto")]  // A
        public int ProdutoFK { get; set; }  // B
        public virtual Produtos Produto { get; set; }  // C

        //  ( ( A * B ) * C )

    }
}