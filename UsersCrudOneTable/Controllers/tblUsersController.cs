using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UsersCrudOneTable;

namespace UsersCrudOneTable.Controllers
{
    public class tblUsersController : Controller
    {
        private UsersEntities db = new UsersEntities();

        // GET: tblUsers
        public ActionResult Index()
        {
            return View(db.tblUsers.ToList());
        }

        // GET: tblUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // GET: tblUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,lastName,firstName,idRol")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUsers);
        }

        // GET: tblUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: tblUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,lastName,firstName,idRol")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUsers);
        }

        // GET: tblUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: tblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsers tblUsers = db.tblUsers.Find(id);
            db.tblUsers.Remove(tblUsers);
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
