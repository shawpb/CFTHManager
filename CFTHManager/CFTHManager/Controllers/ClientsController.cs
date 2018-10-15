using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CFTHManager.DbContexts;
using CFTHManager.Models;

namespace CFTHManager.Controllers
{
	public class ClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.Include(c => c.PersonalInformation ).ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
			var people = db.People.ToList();
			List<SelectListItem> peopleList = new List<SelectListItem>();
			foreach (Person item in people)
			{
				peopleList.Add(new SelectListItem
				{
					Text = item.LastName + ", " + item.FirstName,
					Value = item.Id.ToString()
				});
			}
			ViewBag.Person = peopleList;
			return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
			var people = db.People.ToList();
			List<SelectListItem> peopleList = new List<SelectListItem>();
			foreach (Person item in people)
			{
				peopleList.Add(new SelectListItem
				{
					Text = item.LastName + ", " + item.FirstName,
					Value = item.Id.ToString()
				});
			}
			ViewBag.Person = peopleList;
			return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonalInformationId,FamilySize,AgencyPickUp,CfhToDeliver,EnteredDate,AdvocateId,IntakePersonId,DataEntryPersonId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonalInformationId,FamilySize,AgencyPickUp,CfhToDeliver,EnteredDate,AdvocateId,IntakePersonId,DataEntryPersonId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
