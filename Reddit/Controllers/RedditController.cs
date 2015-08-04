﻿using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reddit.Controllers
{
    public class RedditController : Controller
    {
        Posts posts = new Posts();

        ApplicationDbContext db = new ApplicationDbContext();


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post)
        {
            posts.RedditDB.Attach(post);
            posts.RedditDB.Add(post);
            posts.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(posts.RedditDB.Find(ID));
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            posts.RedditDB.Remove(posts.RedditDB.Find(post.ID));
            posts.RedditDB.Add(post);
            posts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(posts.RedditDB.ToList().OrderByDescending(p => p.ConsolidatedVotes));
        }

        public ActionResult Details(int ID)
        {
            return View(posts.RedditDB.Find(ID));
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            return View(posts.RedditDB.Find(ID));
        }
        [HttpPost]
        public ActionResult Delete(Post post)
        {
            posts.RedditDB.Attach(post);
            posts.RedditDB.Remove(post);
            posts.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult VoteUp(int ID)
        {
            Post post = posts.RedditDB.Find(ID);
            post.PositiveVote++;
            posts.SaveChanges();
            return Content(post.ConsolidatedVotes.ToString());
        }
        public ActionResult VoteDown(int ID)
        {
            Post post = posts.RedditDB.Find(ID);
            post.NegativeVote--;
            posts.SaveChanges();
            return Content(post.ConsolidatedVotes.ToString());
        }
    }
}