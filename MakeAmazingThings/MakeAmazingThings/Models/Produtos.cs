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
            ListaDeCompras = new HashSet<DescricaoCompra>();

            
        }
        
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public string NomeProd { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Publico Alvo")]
        public string SexoDoUtilizador { get; set; }
        
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Stock Disponivel")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public decimal IvaVenda { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public bool Ativo { get; set; }  // situacao do produto

        public string Fotografia { get; set; }




        //************************************************************************************************
        // referência às fotografias associadas a um Produto
        public virtual ICollection<DescricaoCompra> ListaDeCompras { get; set; }

    }
}