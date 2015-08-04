using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            List<Article> displayList = new List<Article>();
            displayList = db.Articles.ToList<Article>();
            
            return View(displayList.OrderByDescending(x => x.Popularity));
        }
        
        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Submitted,Headline,Url,PictureUrl,UpVotes,DownVotes")] Article article)
        {
           
            if (ModelState.IsValid)
            {
                article.Submitted = DateTime.Now;
                article.UpVotes = 0;
                article.DownVotes = 0; 
                db.Articles.AddOrUpdate(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
           
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Submitted,Headline,Url,PictureUrl,UpVotes,DownVotes")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        
        public ActionResult RecordUpVote(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.Id == id);
            
            article.UpVotes++;
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return Content(article.Popularity.ToString());
            }

        public ActionResult RecordDownVote(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.Id == id);
           
            article.DownVotes++;
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return Content(article.Popularity.ToString());
        }
    }
    }

