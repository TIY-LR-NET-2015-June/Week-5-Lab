﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab5_Jason.Models;

namespace lab5_Jason.Controllers
{
    public class RedditPostsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult UpVote(int id)
        {
            var post  = db.RedditPosts.Find(id);
            post.UpVote++;
            db.SaveChanges();
            return Content(post.TotalVotes.ToString());
        }

        public ActionResult DownVote(int id)
        {
            var post = db.RedditPosts.Find(id);
            post.DownVote++;
            db.SaveChanges();
            return Content(post.TotalVotes.ToString());
        }

        public ActionResult Index()
        {
            return View(db.RedditPosts.ToList());
        }

        // GET: RedditPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // GET: RedditPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RedditPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.RedditPosts.Add(redditPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redditPost);
        }

        // GET: RedditPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redditPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redditPost);
        }

        // GET: RedditPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedditPost redditPost = db.RedditPosts.Find(id);
            db.RedditPosts.Remove(redditPost);
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
