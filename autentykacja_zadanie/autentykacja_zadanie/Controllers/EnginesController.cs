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
using autentykacja_zadanie.ViewModels;
using autentykacja_zadanie.Validation;

namespace autentykacja_zadanie.Controllers
{
    public class EnginesController : Controller
    {
        private IEnginesRepository _enginesRepository;
        public EnginesController(IEnginesRepository enginesRepository)
        {
            _enginesRepository = enginesRepository;
        }

        // GET: Engines
        public ActionResult Index()
        {
            var engineVM = new VMEngines();
            engineVM.EngineList = new List<Engine>();
            engineVM.EngineList = _enginesRepository.GetWhere(x => x.Id > 0); 
            return View(engineVM);
        }

        // GET: Engines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngines();
            engineVM.Engine = _enginesRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();

            if (engineVM == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // GET: Engines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEngines model)
        {

            var validator = new EngineValidator();
            var result = validator.Validate(model.Engine);
            if (result.Errors.Any())
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            else
            {
                _enginesRepository.Create(model.Engine);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Engines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngines();
            engineVM.Engine = _enginesRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (engineVM == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // POST: Engines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMEngines model)
        {
            if (ModelState.IsValid)
            {
                _enginesRepository.Update(model.Engine);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Engines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngines();
            engineVM.Engine = _enginesRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (engineVM.Engine == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // POST: Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engine engine = _enginesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _enginesRepository.Delete(engine);
            return RedirectToAction("Index");
        }

        
    }
}
