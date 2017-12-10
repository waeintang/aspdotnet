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
        ClientDataRepository repo = RepositoryHelper.GetClientDataRepository();

        public ActionResult Index()
        {
            var data = repo.All().Where(p => p.IsDeleted == false);

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
                repo.Add(data);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = repo.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientData data)
        {
            if (ModelState.IsValid)
            {
                var item = repo.Find(id);


                item.ClientName = data.ClientName;
                item.ContactAddress = data.ContactAddress;
                item.EINNumber = data.EINNumber;
                item.Email = data.Email;
                item.Fax = data.Fax;

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(repo.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var item = repo.Find(id);

            item.IsDeleted = true;

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}

