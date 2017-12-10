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
    public class ClientDataController : Controller
    {
        private ClientEntities db = new ClientEntities();

        // GET: ClientData
        public ActionResult Index()
        {
            return View(db.ClientData.ToList());
        }

        // GET: ClientData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientData clientData = db.ClientData.Find(id);
            if (clientData == null)
            {
                return HttpNotFound();
            }
            return View(clientData);
        }

        // GET: ClientData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientData/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientName,EINNumber,Phone,Fax,ContactAddress,Email")] ClientData clientData)
        {
            if (ModelState.IsValid)
            {
                db.ClientData.Add(clientData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientData);
        }

        // GET: ClientData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientData clientData = db.ClientData.Find(id);
            if (clientData == null)
            {
                return HttpNotFound();
            }
            return View(clientData);
        }

        // POST: ClientData/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientName,EINNumber,Phone,Fax,ContactAddress,Email")] ClientData clientData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientData);
        }

        // GET: ClientData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientData clientData = db.ClientData.Find(id);
            if (clientData == null)
            {
                return HttpNotFound();
            }
            return View(clientData);
        }

        // POST: ClientData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientData clientData = db.ClientData.Find(id);
            db.ClientData.Remove(clientData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult List()
        {
            var data = from p in db.ClientData
                       select new ClientDataListVM()
                       {
                          ClientName = p.ClientName,
                          EINNumber = p.EINNumber,
                          Phone = p.Phone,
                          Fax = p.Fax,
                          ContactAddress = p.ContactAddress,
                          Email = p.Email
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
