using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ClientContactEFController : Controller
    {
        private ClientEntities db = new ClientEntities();
        // GET: ClientContactEF
        public ActionResult Index()
        {
            var data = from p in db.ClientContact
                       where p.IsDeleted == false
                       select p;

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientContact data)
        {
            if (ModelState.IsValid)
            {
                db.ClientContact.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = db.ClientContact.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientContact data)
        {
            if (ModelState.IsValid)
            {
                var item = db.ClientContact.Find(id);

                item.ClientName = data.ClientName;
                item.ClientPhone = data.ClientPhone;
                item.ClientMobile = data.ClientMobile;
                item.ClientEmail = data.ClientEmail;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(db.ClientContact.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var item = db.ClientContact.Find(id);

            item.IsDeleted = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}