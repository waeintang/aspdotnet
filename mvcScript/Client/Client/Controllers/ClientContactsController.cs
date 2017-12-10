using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Client.Models;
using Client.ViewModels;

namespace Client.Controllers
{
    public class ClientContactsController : Controller
    {
        private ClientEntities db = new ClientEntities();

        // GET: ClientContacts
        public ActionResult Index()
        {
            var clientContact = db.ClientContact.Include(c => c.ClientData);
            return View(clientContact.ToList());
        }

        // GET: ClientContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContact.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            return View(clientContact);
        }

        // GET: ClientContacts/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName");
            return View();
        }

        // POST: ClientContacts/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,Occupation,ClientName,ClientEmail,ClientMobile,ClientPhone")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                db.ClientContact.Add(clientContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientContact.ClientId);
            return View(clientContact);
        }

        // GET: ClientContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContact.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientContact.ClientId);
            return View(clientContact);
        }

        // POST: ClientContacts/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,Occupation,ClientName,ClientEmail,ClientMobile,ClientPhone")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientContact.ClientId);
            return View(clientContact);
        }

        // GET: ClientContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContact.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            return View(clientContact);
        }

        // POST: ClientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientContact clientContact = db.ClientContact.Find(id);
            db.ClientContact.Remove(clientContact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            var data = from p in db.ClientContact
                       select new ClientContactListVM()
                       {
                           Occupation = p.Occupation,
                           ClientName = p.ClientName,
                           ClientEmail = p.ClientEmail,
                           ClientMobile = p.ClientMobile,
                           ClientPhone = p.ClientPhone
                       };
            return View(data);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
