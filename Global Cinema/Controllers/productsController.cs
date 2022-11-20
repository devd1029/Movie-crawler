using Global_Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Global_Cinema.Controllers
{
    public class productsController : Controller
    {
        movieContext mContext = new movieContext();
        // GET: movies
        public ActionResult Index()
        {
            return View(mContext.movieTable.ToList());
        }

        //GET: single item
        public ActionResult Details(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Movie selection is required");
        }


        //PUT : Edit view
        public ActionResult Edit(int id)
        {
            var result = mContext.movieTable.Find(id);
            return View(result);
        }

        //PUT : update the item
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                var result = mContext.movieTable.Find(movie.Id);
                if (result.Id == movie.Id)
                {
                    result.Name = movie.Name;
                    result.Language = movie.Language;
                    result.Types = movie.Types;
                    result.Year = movie.Year;
                    result.imageUrl = movie.imageUrl;
                    mContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Ex.StackTrace);
            }


        }

        public ActionResult Create()
        {
            return View();
        }
        //ADD : movies
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                mContext.movieTable.Add(movie);
                mContext.SaveChanges();
            }
            catch (Exception Ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,Ex.StackTrace);
            }

            return RedirectToAction("Index");
        }
    }
}