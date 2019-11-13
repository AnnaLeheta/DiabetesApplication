using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiabetesProject.Models;
using Newtonsoft.Json;

namespace DiabetesProject.Controllers
{
    public class A1CController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: A1C
        public ActionResult Index()
        {
            A1CViewModel model = GetA1cForThisUser();
            return View(model);
        }

        public ActionResult Chart()
        {
            A1CViewModel model = GetA1cForThisUser();
            model.Chart.Write("bmp");
            return null;
        }


        private A1CViewModel GetA1cForThisUser()
        {
            var a1C = db.A1C.Include(a => a.User);
            A1CViewModel model = new A1CViewModel(a1C.ToList());
            return model;
        }

        // GET: A1C/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A1C a1C = await db.A1C.FindAsync(id);
            if (a1C == null)
            {
                return HttpNotFound();
            }
            return View(a1C);
        }

        // GET: A1C/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName");
            return View();
        }

        // POST: A1C/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "A1cID,UserID,SugarConcentration,Date")] A1C a1C)
        {
            if (ModelState.IsValid)
            {
                db.A1C.Add(a1C);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", a1C.UserID);
            return View(a1C);
        }

        // GET: A1C/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A1C a1C = await db.A1C.FindAsync(id);
            if (a1C == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", a1C.UserID);
            return View(a1C);
        }

        // POST: A1C/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "A1cID,UserID,SugarConcentration,Date")] A1C a1C)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a1C).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", a1C.UserID);
            return View(a1C);
        }

        // GET: A1C/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A1C a1C = await db.A1C.FindAsync(id);
            if (a1C == null)
            {
                return HttpNotFound();
            }
            return View(a1C);
        }

        // POST: A1C/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            A1C a1C = await db.A1C.FindAsync(id);
            db.A1C.Remove(a1C);
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
