using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class WebDeveloperInitializer : DropCreateDatabaseAlways<WebContextDb>
    { 
        protected override void Seed(WebContextDb context)
        {
            var clients = new List<Client>
            {
                    new Client { Name="Jose", LastName="Perez"},
                    new Client { Name="Juan", LastName="Perez"},
                    new Client { Name="Maria", LastName="Perez"},
                    new Client { Name="Gloria", LastName="Perez"},
                    new Client { Name="Juanelo", LastName="Perez"},
                    new Client { Name="Alan", LastName="Perez"},
                    new Client { Name="Pedro", LastName="Perez"}

            };

            //var products = new List<Product>
            //{
            //        new Product { Description="Product", Price=10, ExpirationDate=DateTime.Now,Observation="HOLA" }

            //};

            clients.ForEach(c => context.Clients.Add(c));
          /*  products.ForEach(p => context.Products.Add(p));*/
            context.SaveChanges();


        }
    }
}
