using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cwiczenie.Models;
using cwiczenie.Repository;

namespace cwiczenie.Controllers
{
    public class ContactFormsController : Controller
    {

        private ContactFormRepository _contactFromRepository;
        public ContactFormsController()
        {

            _contactFromRepository = new ContactFormRepository();

        }
        

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(_contactFromRepository.GetWhere(x=>x.Id>0));
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _contactFromRepository.GetWhere(x=>x.Id==id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactFromRepository.Create(contactForm);
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }

       
        

        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _contactFromRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = _contactFromRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _contactFromRepository.Delete(contactForm);
            return RedirectToAction("Index");
        }

       
    }
}
