using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ClientInformationEFController : Controller
    {
        private ClientEntities db = new ClientEntities();
        // GET: ClientInformationEF
        public ActionResult Index()
        {
            var data = from p in db.ClientInformation
                       where p.IsDeleted == false
                       select p  ;

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientInformation data)
        {
            if (ModelState.IsValid)
            {
                db.ClientInformation.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = db.ClientInformation.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientInformation data)
        {
            if (ModelState.IsValid)
            {
                var item = db.ClientInformation.Find(id);

                item.AccountName = data.AccountName;
                item.AccountNo = data.AccountNo;
                item.BankCode = data.BankCode;
                item.BankName = data.BankName;
                item.BranchBankCode = data.BranchBankCode;
              
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(db.ClientInformation.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var item = db.ClientInformation.Find(id);

            item.IsDeleted = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }

}