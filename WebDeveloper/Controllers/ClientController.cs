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
        private ClientData _client=new ClientData();
        
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
            Client p = new Client();   
            foreach (Client pn in _client.GetList())
            {
                if (pn.ID == ID)
                {
                    p.ID = pn.ID;
                    p.Name = pn.Name;
                    p.LastName = pn.LastName;
                    
                    
                }
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Client c)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", c);
            }

            foreach (Client pn in _client.GetList())
            {
                if (pn.ID == c.ID)
                {
                    pn.Name = c.Name;
                    pn.LastName = c.LastName;
                    pn.ID = c.ID;
                    _client.Update(c);
                }
            }

            return RedirectToAction("Index");
        }


    }
}