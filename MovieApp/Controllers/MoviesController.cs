using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBEntities db = new MovieDBEntities();

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            return View(await db.tblMovies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMovy tblMovy = await db.tblMovies.FindAsync(id);
            if (tblMovy == null)
            {
                return HttpNotFound();
            }
            return View(tblMovy);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,releaseDate,director,email,language,category")] tblMovy tblMovy)
        {
            if (ModelState.IsValid)
            {
                db.tblMovies.Add(tblMovy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblMovy);
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMovy tblMovy = await db.tblMovies.FindAsync(id);
            if (tblMovy == null)
            {
                return HttpNotFound();
            }
            return View(tblMovy);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,releaseDate,director,email,language,category")] tblMovy tblMovy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMovy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblMovy);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMovy tblMovy = await db.tblMovies.FindAsync(id);
            if (tblMovy == null)
            {
                return HttpNotFound();
            }
            return View(tblMovy);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblMovy tblMovy = await db.tblMovies.FindAsync(id);
            db.tblMovies.Remove(tblMovy);
            await db.SaveChangesAsync();
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
