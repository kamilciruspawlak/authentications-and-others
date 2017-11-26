using autentykacja_zadanie.ApiConsumer;
using autentykacja_zadanie.ApiConsumer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace autentykacja_zadanie.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public async Task<ActionResult> Index()
        {
            var client = new Client();
            var models =  await client.GetAll();
            return View(models);
        }

        // GET: Performance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performance/Create
        [HttpPost]
        public async Task<ActionResult> Create(Performance model)
        {
           
            var client = new Client();
            var models = await client.SetPerformance(model);
            return RedirectToAction("Index");
            
        }

        // GET: Performance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Performance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Performance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
