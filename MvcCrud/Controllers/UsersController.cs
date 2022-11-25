using MvcCrud.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class UsersController : Controller
    {
        private MvcCrudModel db = new MvcCrudModel();

        // GET: User
        public ActionResult Index()
        {
            if (TempData["Info"] != null)
                ViewBag.Info = TempData["Info"].ToString();

            var users = db.Users.ToList();

            var orderedUsers = users.OrderBy(s => s.Name);

            return View(orderedUsers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);

        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        // For more details see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(user);
                db.SaveChanges();

                TempData["Info"] = "User has been created";

                return RedirectToAction("Index");
            }

            ViewBag["Info"] = "User is created successfully";
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        // For more details see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LoginName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Info = "Student successfully edited";

                return View(user);
            }

            return View(user);
        }

        // POST: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (TempData["Info"] != null)
                ViewBag.Info = TempData["Info"].ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        // Delete Confirmation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);

            if (user.Units.Count() == 0)
            {
                db.Users.Remove(user);
                db.SaveChanges();

                TempData["Info"] = "User has been deleted";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Info = "User can not be deleted";
                return View(user);
            }
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