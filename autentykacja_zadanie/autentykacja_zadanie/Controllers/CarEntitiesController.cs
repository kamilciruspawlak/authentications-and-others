using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autentykacja_zadanie.Models;
using autentykacja_zadanie.Repository.Interfaces;
using autentykacja_zadanie.Intetfaces;
using autentykacja_zadanie.ViewModels;

namespace autentykacja_zadanie.Controllers
{
    public class CarEntitiesController : Controller
    {
        
        private ICarsRepository _carsRepository;
        private ICarBusinessLogic _carBusinessLogic;
        public CarEntitiesController(ICarsRepository carsRepository, ICarBusinessLogic carBusinessLogic)
        {
            _carsRepository = carsRepository;
            _carBusinessLogic = carBusinessLogic;

        }
        // GET: CarEntities
        public ActionResult Index()
        {
            var carVM = new VMCars(); 
            carVM.CarList = new List<CarEntity>();
            carVM.ShowIfAuth = _carBusinessLogic.CheckIfUserIsAuthorize();
            if (carVM.ShowIfAuth)
            {
                carVM.CarList = _carsRepository.GetWhere(x => x.Id > 0);
            }
            else
            {
                carVM.CarList = _carsRepository.GetWhere(x => x.Id > 0 && x.isActive);
               
            }
            return View(carVM);
        }

        // GET: CarEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = new VMCars();
            
           
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _carBusinessLogic.CheckIfUserIsAuthorize();
            if (carVM == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // GET: CarEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMCars carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _carBusinessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Create(carEntity.Car);
                    return RedirectToAction("Index");
            }

            return View(carEntity);
        }

        // GET: CarEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = new VMCars();
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _carBusinessLogic.CheckIfUserIsAuthorize();
            if (carVM == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: CarEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMCars carEntity)
        {
            
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _carBusinessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Update(carEntity.Car);
                return RedirectToAction("Index");
            }
            return View(carEntity);
        }

        // GET: CarEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            var carVM = new VMCars();
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _carBusinessLogic.CheckIfUserIsAuthorize();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: CarEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarEntity carEntity = _carsRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _carsRepository.Delete(carEntity);
            return RedirectToAction("Index");
        }


    }
}
