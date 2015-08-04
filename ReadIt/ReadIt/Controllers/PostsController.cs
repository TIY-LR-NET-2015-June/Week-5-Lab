using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadIt.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Diagnostics;
using ReadIt;


namespace ReadIt.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {

            return View(db.Posts.ToList().OrderByDescending(x => x.GetVoteTotal()));
        }

        [Authorize]
        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedOn = DateTime.Now;

                var userId = User.Identity.GetUserId();
                post.User = db.Users.Find(userId);

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }


        public ActionResult UpVote(int id)
        {
            Post post = db.Posts.Find(id);
            post.UpVote();
            db.SaveChanges();
            return Content(post.GetVoteTotal().ToString());
        }
        public ActionResult DownVote(int id)
        {
            Post post = db.Posts.Find(id);
            post.DownVote();
            db.SaveChanges();
            return Content(post.GetVoteTotal().ToString());
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
