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
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class CommentsController : Controller
    {
        private BlogAppContext db = new BlogAppContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Blog).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Comment comment = db.Comments.Find(id);
            //if (comment == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(comment);
            using (var uow=new UnitOfWork())
            {
                var blog = uow.BlogRepository.Get(b => b.Id == id);
                var blogDetailViewModel = new BlogDetailViewModel()
                {
                    AuthorName = blog.User.UserName,
                    Body = blog.Body,
                    CreationTime = blog.CreateTime,
                    Id = blog.Id,
                    Title = blog.Title,
                    UpdateTime = blog.UpdateTime,
                    CategoryName = blog.Category.CategoryName
                };
                List<CommentViewModel> commentList = blog.Comments.Select(comment => new CommentViewModel
                {
                    PosterName = comment.User.UserName,
                    Message = comment.Body,
                    CreationTime = comment.CreateTime
                }).ToList();
                ViewData["Comments"] = commentList;
                return View(blogDetailViewModel);
            }
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title");
            ViewBag.PosterId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,CreateTime,BlogId,PosterId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "UserName", comment.PosterId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "UserName", comment.PosterId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,CreateTime,BlogId,PosterId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "UserName", comment.PosterId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Comment comment = db.Comments.Find(id);
            //if (comment == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(comment);

            try
            {
                using (var uow=new UnitOfWork())
                {
                    var comment = uow.CommentRepository.Get(c => c.Id == id);
                    uow.CommentRepository.Delete(comment);
                    uow.SavaChanges();
                }
                return Content("OK");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
