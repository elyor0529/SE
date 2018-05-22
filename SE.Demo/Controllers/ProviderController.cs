using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SE.Model.Entity;
using SE.Service;

namespace SE.Demo.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService _service;

        public ProviderController(IProviderService service)
        {
            _service = service;
        }

        // GET: Provider
        public ActionResult Index()
        {
            var model = _service.GetAll();

            return View(model);
        }

        // GET: Provider/Details/5
        public ActionResult Details(long id)
        {
            var model = _service.GetById(id);

            return View(model);
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            var model = new SearchProvider();

            return View(model);
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(SearchProvider model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _service.Create(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.GetById(id);

            return View(model);
        }

        // POST: Provider/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SearchProvider model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _service.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _service.GetById(id);

            return View(model);
        }

        // POST: Provider/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SearchProvider model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _service.Delete(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
