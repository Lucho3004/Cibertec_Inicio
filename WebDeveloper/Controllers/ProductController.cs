using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class ProductController : Controller
    {

        private ProductData _product= new ProductData();

        // GET: Product
        public ActionResult Index()
        {
            return View(_product.GetList());
        }
        public ActionResult Create()
        {
            return View(new Product());


        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _product.Add(product);
                return RedirectToAction("Index");

            }
            return View();
        }


        public ActionResult Edit(int ID)
        {
            var product = _product.GetProductByID(ID);

            if (product == null)
                RedirectToAction("Index");
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }

            if (_product.Update(product) > 0)
                return RedirectToAction("Index");
            return View(product);
        }

        public ActionResult Delete(int ID)
        {

            var product = _product.GetProductByID(ID);

            if (product == null)
                RedirectToAction("Index");
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {

            if (_product.Delete(product) > 0)
                return RedirectToAction("Index");
            return View(product);
        }
    }
}