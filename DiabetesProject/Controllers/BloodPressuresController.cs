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

namespace DiabetesProject.Controllers
{
    public class BloodPressuresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodPressures
        public async Task<ActionResult> Index()
        {
            var bloodPressures = db.BloodPressures.Include(b => b.User);
            return View(await bloodPressures.ToListAsync());
        }

        // GET: BloodPressures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodPressure bloodPressure = await db.BloodPressures.FindAsync(id);
            if (bloodPressure == null)
            {
                return HttpNotFound();
            }
            return View(bloodPressure);
        }

        // GET: BloodPressures/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName");
            return View();
        }

        // POST: BloodPressures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodPressureID,UserID,SystolicPressure,DiastolicPressure,Pulse,MeasuredArm,Date")] BloodPressure bloodPressure)
        {
            if (ModelState.IsValid)
            {
                db.BloodPressures.Add(bloodPressure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodPressure.UserID);
            return View(bloodPressure);
        }

        // GET: BloodPressures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodPressure bloodPressure = await db.BloodPressures.FindAsync(id);
            if (bloodPressure == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodPressure.UserID);
            return View(bloodPressure);
        }

        // POST: BloodPressures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodPressureID,UserID,SystolicPressure,DiastolicPressure,Pulse,MeasuredArm,Date")] BloodPressure bloodPressure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodPressure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodPressure.UserID);
            return View(bloodPressure);
        }

        // GET: BloodPressures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodPressure bloodPressure = await db.BloodPressures.FindAsync(id);
            if (bloodPressure == null)
            {
                return HttpNotFound();
            }
            return View(bloodPressure);
        }

        // POST: BloodPressures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodPressure bloodPressure = await db.BloodPressures.FindAsync(id);
            db.BloodPressures.Remove(bloodPressure);
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
