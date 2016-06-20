using System.Linq;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class ProductData : BaseDataAccess<Product>
    {

        public Product GetProductByID(int id)
        {
            using (var dbContext = new WebContextDb())
            {

                return dbContext.Products.FirstOrDefault(x => x.ID == id);
            }
        }

    }
}
