using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class ClientInformationsController : Controller
    {
        private ClientEntities db = new ClientEntities();

        // GET: ClientInformations
        public ActionResult Index()
        {
            var clientInformation = db.ClientInformation.Include(c => c.ClientData);
            return View(clientInformation.ToList());
        }

        // GET: ClientInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientInformation = db.ClientInformation.Find(id);
            if (clientInformation == null)
            {
                return HttpNotFound();
            }
            return View(clientInformation);
        }

        // GET: ClientInformations/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName");
            return View();
        }

        // POST: ClientInformations/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,BankName,BankCode,BranchBankCode,AccountName,AccountNo")] ClientInformation clientInformation)
        {
            if (ModelState.IsValid)
            {
                db.ClientInformation.Add(clientInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientInformation.ClientId);
            return View(clientInformation);
        }

        // GET: ClientInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientInformation = db.ClientInformation.Find(id);
            if (clientInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientInformation.ClientId);
            return View(clientInformation);
        }

        // POST: ClientInformations/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,BankName,BankCode,BranchBankCode,AccountName,AccountNo")] ClientInformation clientInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.ClientData, "Id", "ClientName", clientInformation.ClientId);
            return View(clientInformation);
        }

        // GET: ClientInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientInformation = db.ClientInformation.Find(id);
            if (clientInformation == null)
            {
                return HttpNotFound();
            }
            return View(clientInformation);
        }

        // POST: ClientInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientInformation clientInformation = db.ClientInformation.Find(id);
            db.ClientInformation.Remove(clientInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
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
