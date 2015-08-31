using System;
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
        public List<RedditPost> GetPosts()
        {
            List<RedditPost> posts = (List<RedditPost>)Session["BlogPosts"];
            if (posts == null)
            {
                posts = new List<RedditPost>();
                db.RedditPosts.Add(new RedditPost() { Name = "Jason Williams", Id = 1, URL = "https://www.google.com", PostTime = DateTime.Now });
                db.RedditPosts.Add(new RedditPost() { Name = "Jason Williams", Id = 2, URL = "https://www.facebook.com", PostTime = DateTime.Now.AddMonths(-1) });
                db.RedditPosts.Add(new RedditPost() { Name = "Dainel Pollock", Id = 3, URL = "https://www.twitter.com", PostTime = DateTime.Now.AddDays(-5) });
                db.SaveChanges();
            }

            return posts;
        }
        public void AddPost(RedditPost p)
        {
            var posts = GetPosts();

            p.Id = posts.Max(x => x.Id) + 1;

            posts.Add(p);

            SavePosts(posts);
        }
        public void SavePosts(List<RedditPost> Posts)
        {
            Session["BlogPosts"] = Posts;
        }

        // GET: RedditPosts
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
            if (!ModelState.IsValid)
            {
                return View(redditPost);
            }
            try
            {
                redditPost.PostTime = DateTime.Now;
                db.RedditPosts.Add(redditPost);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RedditPosts/Edit/5
        public ActionResult Edit(int id)

        {
            var post = GetPosts().FirstOrDefault(x => x.Id == id);

            return View(post);
        }

        // POST: RedditPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RedditPost editRedditPost)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //do the update with edittedpost
                    var posts = GetPosts();
                    var post = posts.FirstOrDefault(x => x.Id == editRedditPost.Id);
                    db.RedditPosts.Remove(post);
                    db.RedditPosts.Add(editRedditPost);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RedditPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = GetPosts().FirstOrDefault(x => x.Id == id);
            return View(post);
        }

        // POST: RedditPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var posts = GetPosts();
            var post = posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                posts.Remove(post);
                SavePosts(posts);
            }

            return RedirectToAction("Index");
        }
    }
}
