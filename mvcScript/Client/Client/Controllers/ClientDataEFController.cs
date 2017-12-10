using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ClientDataEFController : Controller
    {
        private ClientEntities db = new ClientEntities();
        // GET: ClientDataEF
        public ActionResult Index()
        {
            var data = from p in db.ClientData
                       where p.IsDeleted == false
                       select p;

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientData data)
        {
            if (ModelState.IsValid)
            {
                db.ClientData.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = db.ClientData.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientData data)
        {
            if (ModelState.IsValid)
            {
                var item = db.ClientData.Find(id);

                item.ClientName = data.ClientName;
                item.ContactAddress = data.ContactAddress;
                item.EINNumber = data.EINNumber;
                item.Email = data.Email;
                item.Fax = data.Fax;


                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(db.ClientData.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var item = db.ClientData.Find(id);

            item.IsDeleted = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}