using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class ClientController : Controller
    {
        private ClientData _client = new ClientData();

        // GET: Client
        public ActionResult Index()
        {

            return View(_client.GetList());
        }

        public ActionResult Create()
        {
            return View(new Client());


        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _client.Add(client);
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Edit(int ID)
        {
            var client = _client.GetClientByID(ID);

            if (client == null)
                RedirectToAction("Index");
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", client);
            }

            if (_client.Update(client) > 0)
                return RedirectToAction("Index");
                return View(client);
        }

        public ActionResult Delete(int ID)
        {

            var client = _client.GetClientByID(ID);

            if (client == null)
                RedirectToAction("Index");
            return View(client);
        }
        [HttpPost]
        public ActionResult Delete(Client client)
        {
            
            if (_client.Delete(client)>0)
                return RedirectToAction("Index");
            return View(client);
        }

    }
}