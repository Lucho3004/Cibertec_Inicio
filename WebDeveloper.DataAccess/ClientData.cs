
using System.Collections.Generic;
using System.Linq;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class ClientData :BaseDataAccess<Client>
    {

        //public List<Client> GetFakeData()
        //{
        //    return new List<Client>
        //    {
        //            new Client { ID=1, Name="Juan", LastName="Perez"},
        //            new Client { ID=1, Name="Raul", LastName="Ruidiaz"}
        //    };
        //}

        //public List<Client> GetList()
        //{
        //    using (var dbContext = new WebContextDb())
        //    {
        //        return dbContext.Clients.ToList();

        //    }
        //}

        public Client GetClientByID(int id)
        {
            using (var dbContext = new WebContextDb())
            {

                return dbContext.Clients.FirstOrDefault(x=>x.ID==id);
            }
        }

    }
}
