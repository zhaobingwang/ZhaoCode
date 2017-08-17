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
    public class BlogsController : Controller
    {
        private BlogAppContext db = new BlogAppContext();

        // GET: Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category).Include(b => b.User);
            return View(blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Blog blog = db.Blogs.Find(id);
            //if (blog == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(blog);
            using (var uow=new UnitOfWork())
            {
                var blog = uow.BlogRepository.Get(b => b.Id == id);
                var blogDetailViewModel = new BlogDetailViewModel
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
                    CreationTime = comment.CreateTime,
                    Id = comment.Id
                }).ToList();
                ViewData["Comments"] = commentList;
                return View(blogDetailViewModel);
            }
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            //ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    blog.CreateTime = DateTime.Now;
                    blog.UpdateTime = DateTime.Now;
                    //blog.AuthorId = uow.UserRepository.Get(u => u.UserName == User.Identity.Name).Id;//以后加入Identity技术时使用
                    blog.AuthorId = 1;
                    uow.BlogRepository.Insert(blog);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Blog blog = db.Blogs.Find(id);
            //if (blog == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            //ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName", blog.AuthorId);
            //return View(blog);

            using (var uow = new UnitOfWork())
            {
                var categories = uow.CategoryRepository.GetAllList().ToList();
                ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
                var blog = uow.BlogRepository.Get(b => b.Id == id);
                return View(blog);
            }
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(blog).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            //ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName", blog.AuthorId);
            //return View(blog);
            try
            {
                using (var uow = new UnitOfWork())
                {
                    blog.UpdateTime = DateTime.Now;
                    uow.BlogRepository.Update(blog);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Blog blog = db.Blogs.Find(id);
            //if (blog == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(blog);
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var blog = uow.BlogRepository.Get(b => b.Id == id);
                    uow.BlogRepository.Delete(blog);
                    uow.SavaChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
