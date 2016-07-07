using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.ActionFilters;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    [Authorize]
    [LogActionFilter]
    [RoutePrefix("Razor")]

    public class RazorController : Controller
    {

        // GET: Razor
        [Route]
        public ActionResult Index()
        {
            var clients = new List<Client>
            {
                new Client { ID = 1, LastName = "Cueva", Name = "Aladino" },
                new Client { ID = 2, LastName = "Ruidiaz", Name = "Raul" },
                new Client { ID =3, LastName = "Peredo", Name = "José" }
            };


            return View(clients);
        }
        public ActionResult Product()
        {
            var productData = new ProductData();
            return View(productData.GetFakeProducts());
        }

        [Route("Entry/{date:Datetime}")]
        public ActionResult EntryDate(DateTime date)
        {
            ViewBag.Date = date.ToShortDateString();
            return View();
        }


        [Route("Entry/{id:int}")]
        public string EntryId(int id)
        {
            return id.ToString();
        }
    }
}