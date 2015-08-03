using MikeIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MikeIt.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index()
        {
            List<Post> displayList = new List<Post>();
            displayList = db.Posts.ToList<Post>();
            return View(displayList.OrderByDescending(x => x.UpVotes));
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here
                post.SubmittedOn = DateTime.Now;
                post.UpVotes = 0;
                db.Posts.AddOrUpdate(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Post post)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    {
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Post post)
        {
            try
            {
                // TODO: Add delete logic here
                Post apost = db.Posts.Find(id);

                db.Posts.Remove(apost);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RecordUpVote(int? id, string page)
        {
            Post post = db.Posts.Find(id);
            post.UpVotes++;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(page, new { id = post.PostId });
        }
    }
}
