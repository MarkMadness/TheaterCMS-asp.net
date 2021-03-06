﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheatreCMS.Controllers;

namespace TheatreCMS.Models
{
    public class ProductionPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: ProductionPhotos
        public ActionResult Index()
        {
            var filteredList = db.Productions.OrderByDescending(i => i.Season).ThenBy(i => i.OpeningDay).Select(i => new SelectListItem
            {
                Value = i.ProductionId.ToString(),
                Text = i.Title + " (" + i.Season + ")"
            });
            ViewData["ProductionList"] = new SelectList(filteredList, "Value", "Text");

            return View(db.ProductionPhotos.OrderByDescending(i => i.Production.Season).ThenBy(i => i.Production.OpeningDay).ToList());
        }

        // GET: ProductionPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ProductionPhotos productionPhotos = db.ProductionPhotos.Find(id);
            Production production = db.Productions.Find(id);

            if (productionPhotos == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotos);
        }

        // GET: ProductionPhotos/Create
        public ActionResult Create()
        {
            ViewData["Productions"] = new SelectList(db.Productions.ToList(), "ProductionId", "Title");
            return View();
        }

        // POST: ProductionPhotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Production")] ProductionPhotos productionPhotos, HttpPostedFileBase file)
        {
            int productionID = Convert.ToInt32(Request.Form["Productions"]);
           
            productionPhotos.PhotoId = PhotoController.CreatePhoto(file, productionPhotos.Title);

            if (ModelState.IsValid)
            {
                Production production = db.Productions.Find(productionID);
                productionPhotos.Production = production;

                if (production.DefaultPhoto == null)
                {
                    production.DefaultPhoto = productionPhotos;
                }

                db.ProductionPhotos.Add(productionPhotos);
                db.SaveChanges();      

                return RedirectToAction("Index");
            }
            
            return View(productionPhotos);
        }

        //GET: ProductionPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotos productionPhotos = db.ProductionPhotos.Find(id);
            if (productionPhotos == null)
            {
                return HttpNotFound();
            }

            ViewData["Productions"] = new SelectList(db.Productions, "ProductionId", "Title", productionPhotos.Production.ProductionId);
            return View(productionPhotos);
        }

     
        // POST: ProductionPhotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description,Production")] ProductionPhotos productionPhotos, HttpPostedFileBase file)
        {          
                      
            int productionID = Convert.ToInt32(Request.Form["Productions"]);

            if (ModelState.IsValid)
            {
                var currentProPhoto = db.ProductionPhotos.Find(productionPhotos.ProPhotoId);
                currentProPhoto.Title = productionPhotos.Title;
                currentProPhoto.Description = productionPhotos.Description;

                var production = db.Productions.Find(productionID);
                currentProPhoto.Production = production;

                //if (file != null && file.ContentLength > 0)
                //{
                //    var photo = ImageUploadController.ImageBytes(file, out string _64);
                //    currentProPhoto.Photo = photo;
                //}
                //else
                //{
                //    currentProPhoto.Photo = productionPhotos.Photo;
                //}

                db.Entry(currentProPhoto.Production).State = EntityState.Modified;
                db.SaveChanges();
                db.Entry(currentProPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPhotos);
        }

        // GET: ProductionPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotos productionPhotos = db.ProductionPhotos.Find(id);
            if (productionPhotos == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotos);
        }

        // POST: ProductionPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhotos productionPhotos = db.ProductionPhotos.Find(id);
            db.ProductionPhotos.Remove(productionPhotos);
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

        //File upload GET and POST controls
        public ActionResult UploadImage()
        {
            
            return View();
        }


    }
}
