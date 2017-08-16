using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogAppDAL;
using BlogAppDAL.Entities;
using BlogAppDAL.UOW;

namespace BlogApp.Controllers
{
    public class CategoriesController : Controller
    {
        private BlogAppContext db = new BlogAppContext();

        // GET: Categories
        public ActionResult Index()
        {
            using (var uow=new UnitOfWork())
            {
                var categories = uow.CategoryRepository.GetAllList().ToList();
                return View(categories);
            }
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] Category category)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Categories.Add(category);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(category);
            try
            {
                using (var uow=new UnitOfWork())
                {
                    uow.CategoryRepository.Insert(category);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Category category = db.Categories.Find(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(category);

            using (var uow=new UnitOfWork())
            {
                var category = uow.CategoryRepository.Get(c => c.Id == id);
                return View(category);
            }

        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] Category category)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(category).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(category);

            try
            {
                using (var uow=new UnitOfWork())
                {
                    uow.CategoryRepository.Update(category);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Category category = db.Categories.Find(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(category);

            try
            {
                using (var uow=new UnitOfWork())
                {
                    var category = uow.CategoryRepository.Get(c => c.Id == id);
                    uow.CategoryRepository.Delete(category);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
