using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Global_Cinema.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Global_Cinema.Controllers
{
    public class ImportMoviesController : Controller
    {
        private movieContext db = new movieContext();
        private static readonly HttpClient client = new HttpClient();
        // GET: ImportMovies
        public ActionResult Index()
        {
             return View(db.movieTable.ToList());
        }

        public ActionResult BulkImport(string Url,string header_title, string header_value)
        {
            List<bulkMovie> blkList = new List<bulkMovie>();
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Headers[header_title] = header_value;
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var objects = JsonConvert.DeserializeObject<Root>(responseString);
            var joResponse = JObject.Parse(responseString);
            

            // get JSON result objects into a list
            IList<JToken> results = joResponse["data"]["items"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<bulkMovie> searchResults = new List<bulkMovie>();
            foreach (JToken result in results)
            {
                var x1 = result.Values().ToList();
                bulkMovie bulk = new bulkMovie(result);   
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                
                searchResults.Add(bulk);
            }

            var values = JsonConvert.DeserializeObject<Dictionary<object,object>>(responseString);
            dynamic MyDynamic = JsonConvert.DeserializeObject<Dictionary<object, object>>(responseString);
            JObject ojObject = (JObject)joResponse;

            

            return View(objects);
                    
        }
        // GET: ImportMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.movieTable.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: ImportMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Language,Year,Types,imageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.movieTable.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: ImportMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.movieTable.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: ImportMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Language,Year,Types,imageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: ImportMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.movieTable.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: ImportMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.movieTable.Find(id);
            db.movieTable.Remove(movie);
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
