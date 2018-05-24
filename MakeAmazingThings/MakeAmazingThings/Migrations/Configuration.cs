namespace MakeAmazingThings.Migrations
{
    using MakeAmazingThings.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MakeAmazingThings.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MakeAmazingThings.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var registosDeProdutos = new List<Produtos> {
                new Produtos  {ID =1, Marca="AAA", NomeProd ="Tesoura", Descricao ="Serve para cortar coisas", SexoDoUtilizador="Unisexo", Ativo =true, Preco = 5, IvaVenda =21, Stock =5,  },
                new Produtos  {ID =2,Marca="BBB", NomeProd ="Pente", Descricao ="Serve para pentear coisas", SexoDoUtilizador="Feminino", Ativo =true, Preco = 3.99m, IvaVenda =21, Stock =10, },
                new Produtos  {ID =3,Marca="CCC", NomeProd ="Navalha", Descricao ="Serve para cortar coisas, mas melhor do que uma tesoura", SexoDoUtilizador="Masculino", Ativo =true, Preco = 15, IvaVenda =21, Stock =0, },
                new Produtos  {ID =4,Marca="AAA", NomeProd ="TintaVermelha", Descricao ="Serve para pintar coisas de vermelho", SexoDoUtilizador="Feminino", Ativo =true, Preco = 19.99m, IvaVenda =21, Stock =20, },
                new Produtos  {ID =5,Marca="CCC", NomeProd ="Cera de Cabelo", Descricao ="Serve para pentear coisas", SexoDoUtilizador="Feminino", Ativo =true, Preco = 6.99m, IvaVenda =21, Stock =10, },
                new Produtos  {ID =6,Marca="AAA", NomeProd ="Shampoo", Descricao ="Serve para lavar coisas", SexoDoUtilizador="Unisexo", Ativo =true, Preco = 8, IvaVenda =21, Stock =10,  },
            };
            
            registosDeProdutos.ForEach(pp => context.Produtos.AddOrUpdate(p => p.ID, pp));
            context.SaveChanges();
            
            var registosDeCompradores = new List<Comprador> {
                new Comprador  {ID =1, Nome="Rodolfo Santos" , Morada="Rua 1" , CodPostal ="2300-111", NIF=11111 ,  Telemovel=11111, },
                new Comprador  {ID =2, Nome="Rafael Martinho" , Morada="Rua 2" , CodPostal ="2300-222", NIF=22222 ,  Telemovel=22222},
                new Comprador  {ID =3, Nome="José Alves" , Morada="Rua 3" , CodPostal ="2300-333", NIF=33333 ,  Telemovel=33333},
                new Comprador  {ID =4, Nome="Bruno Carvalho" , Morada="Rua 4" , CodPostal ="2300-444", NIF=44444 ,  Telemovel=44444},
                new Comprador  {ID =5, Nome="Luis Vieira" , Morada="Rua 5" , CodPostal ="2300-555", NIF=55555 ,  Telemovel=55555},
                new Comprador  {ID =6, Nome="Jorge Costa" , Morada="Rua 6" , CodPostal ="2300-666", NIF=66666 ,  Telemovel=66666},
              };

            registosDeCompradores.ForEach(cc => context.Compradores.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();
            
            
            var registosDeFotos = new List<Fotos> {
                new Fotos { ID=1, NomeFoto= "cera.jpg" , Ordem=1 , ProdutoFK=1},
                new Fotos { ID=2, NomeFoto= "pente.jpg" , Ordem=2, ProdutoFK=2 },
                new Fotos { ID=3, NomeFoto= "shampoo.png", Ordem=3 , ProdutoFK=3},
                new Fotos { ID=4, NomeFoto= "Tesoura.jpg", Ordem=4 , ProdutoFK=4},
                new Fotos { ID=5, NomeFoto= "navalha.jpg", Ordem=5 , ProdutoFK=5},
                new Fotos { ID=6, NomeFoto= "tinta vermelha.jpg", Ordem= 6, ProdutoFK=6},
                };


            registosDeFotos.ForEach(ff => context.Fotos.AddOrUpdate(f => f.ID, ff));
            context.SaveChanges();


            var registosDeCompras = new List<Compra> {
                new Compra  {NumFatura =1, Data= new DateTime(2018,05,20) , TotalCiva=10 , TotalSiva=5, CompradorFk=1   },
                new Compra  {NumFatura =2, Data= new DateTime(2018,05,20) , TotalCiva=20 , TotalSiva= 10 , CompradorFk=2},
                new Compra  {NumFatura =3, Data= new DateTime(2018,05,20) , TotalCiva=30 , TotalSiva= 20, CompradorFk=3  },
                new Compra  {NumFatura =4, Data= new DateTime(2018,05,20) , TotalCiva=40 , TotalSiva= 30 , CompradorFk=4 },
                new Compra  {NumFatura =5, Data= new DateTime(2018,05,20) , TotalCiva=50 , TotalSiva= 40  , CompradorFk=5},
                new Compra  {NumFatura =6, Data= new DateTime(2018,05,20) , TotalCiva=60 , TotalSiva= 50, CompradorFk=6  },
                };
            registosDeCompras.ForEach(oo => context.Compras.AddOrUpdate(o => o.NumFatura, oo));
            context.SaveChanges();

            //as seguintes tabelas nao estão a ser inseridas na base dados
            var registosDeDescricao = new List<DescricaoCompra> {
                new DescricaoCompra { ID=1, Quantidade= 2,PrecoVenda= 10, IVA=21, CompraFk=1, ProdutoFk=1 },
                new DescricaoCompra { ID=2, Quantidade= 1,PrecoVenda= 20, IVA=21, CompraFk=2, ProdutoFk=2 },
                new DescricaoCompra { ID=3, Quantidade= 3,PrecoVenda= 30, IVA=21,  CompraFk=3, ProdutoFk=3 },
                new DescricaoCompra { ID=4, Quantidade= 5,PrecoVenda= 40, IVA=21, CompraFk=4, ProdutoFk=4 },
                new DescricaoCompra { ID=5, Quantidade= 2,PrecoVenda= 50, IVA=21 , CompraFk=5, ProdutoFk=5},
                new DescricaoCompra { ID=6, Quantidade= 1,PrecoVenda= 60, IVA=21, CompraFk=6, ProdutoFk=6 },
               };

            registosDeDescricao.ForEach(dd => context.DescricoesCompras.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();
            
            
            
            
            
           
    
            
            
    
        }
    }
}
