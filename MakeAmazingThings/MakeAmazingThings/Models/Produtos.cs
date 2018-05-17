using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeAmazingThings.Models
{
    public class Produtos
    {   
        //construtor
        public Produtos()
        {
            ListaDeFotografias = new HashSet<Fotos>();
            ListaDeCompras = new HashSet<DescricaoCompra>();
        }



        [Key]
        public int ID { get; set; }

        public string NomeProd { get; set; }

        public string Descricao { get; set; }

        public int Stock { get; set; }

        public decimal Preco { get; set; }

        public decimal IvaVenda { get; set; }

        public bool Ativo { get; set; }  // situacao do produto

        //************************************************************************************************
        // referência às fotografias associadas a um Produto
        public virtual ICollection<Fotos> ListaDeFotografias { get; set; }
        public virtual ICollection<DescricaoCompra> ListaDeCompras { get; set; }

    }
}