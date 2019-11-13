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
    public class BloodSugarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodSugars
        public async Task<ActionResult> Index()
        {
            var bloodSugars = db.BloodSugars.Include(b => b.User);
            return View(await bloodSugars.ToListAsync());
        }

        // GET: BloodSugars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSugar bloodSugar = await db.BloodSugars.FindAsync(id);
            if (bloodSugar == null)
            {
                return HttpNotFound();
            }
            return View(bloodSugar);
        }

        // GET: BloodSugars/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName");
            return View();
        }

        // POST: BloodSugars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodSugarID,UserID,SugarConcentration,Measured,Date,Weight")] BloodSugar bloodSugar)
        {
            if (ModelState.IsValid)
            {
                db.BloodSugars.Add(bloodSugar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodSugar.UserID);
            return View(bloodSugar);
        }

        // GET: BloodSugars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSugar bloodSugar = await db.BloodSugars.FindAsync(id);
            if (bloodSugar == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodSugar.UserID);
            return View(bloodSugar);
        }

        // POST: BloodSugars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodSugarID,UserID,SugarConcentration,Measured,Date,Weight")] BloodSugar bloodSugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodSugar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "LastName", bloodSugar.UserID);
            return View(bloodSugar);
        }

        // GET: BloodSugars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSugar bloodSugar = await db.BloodSugars.FindAsync(id);
            if (bloodSugar == null)
            {
                return HttpNotFound();
            }
            return View(bloodSugar);
        }

        // POST: BloodSugars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodSugar bloodSugar = await db.BloodSugars.FindAsync(id);
            db.BloodSugars.Remove(bloodSugar);
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
