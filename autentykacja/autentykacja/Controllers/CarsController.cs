using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autentykacja.Models;
using autentykacja.Repository;
using autentykacja.Repository.Interfaces;

namespace autentykacja.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository _abstractRepository;
        public CarsController(ICarRepository abstractRepository)
        {
            _abstractRepository = abstractRepository;
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View(_abstractRepository.GetWhere(x=>x.Id>0));
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _abstractRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _abstractRepository.Create(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _abstractRepository.GetWhere(x=>x.Id==id.Value).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {

                _abstractRepository.Update(car);
               
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _abstractRepository.GetWhere(x=>x.Id==id.Value).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _abstractRepository.GetWhere(x=>x.Id==id).FirstOrDefault();
            _abstractRepository.Delete(car);
            return RedirectToAction("Index");
        }

        
    }
}
