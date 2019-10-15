using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Areas.Admin.Models;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace Conference.Controllers
{
    public class SponsorTypesController : Controller
    {
        private readonly ISponsorTypeService sponsorTypeService;

        public SponsorTypesController(ISponsorTypeService sponsorTypeService)
        {
            this.sponsorTypeService = sponsorTypeService;
        }


        // GET: SponsorType
        public ActionResult Index()
        {
            IEnumerable<SponsorTypes> allSponsorTypes = sponsorTypeService.GetAllSponsorTypes();
            return View(allSponsorTypes);
        }

        // GET: SponsorType/Details/5
        public ActionResult Details(int id)
        {
            SponsorTypes sponsorTypes = sponsorTypeService.GetSponsorTypeById(id);
            SponsorTypeViewModel model = new SponsorTypeViewModel();
            model.InjectFrom(sponsorTypes);
            return View(sponsorTypes);
        }

        // GET: SponsorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsorTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SponsorTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SponsorTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SponsorTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SponsorTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}