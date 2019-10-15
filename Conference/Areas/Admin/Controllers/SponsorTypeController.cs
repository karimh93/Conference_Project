using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Conference.Areas.Admin.Models;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace Conference.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SponsorTypeController : Controller
    {
        private readonly ISponsorTypeService sponsorTypeService;

        public SponsorTypeController(ISponsorTypeService sponsorTypeService)
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

        // GET: SponsorType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsorType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                SponsorTypes sponsorTypes = new SponsorTypes();
                sponsorTypes.InjectFrom(model);
                var createNewSponsorType = sponsorTypeService.AddSponsorType(sponsorTypes);
                if (createNewSponsorType == null)
                {
                    ModelState.AddModelError("Name", "The Name must be unique!");
                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SponsorType/Edit/5
        public ActionResult Edit(int id)
        {
            var sponsorType = sponsorTypeService.GetSponsorTypeById(id);
            SponsorTypeViewModel model = new SponsorTypeViewModel();
            model.InjectFrom(sponsorType);
            return View(model);
        }

        // POST: SponsorType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SponsorTypeViewModel model)
        {
            SponsorTypes sponsorTypes = new SponsorTypes();
            sponsorTypes.InjectFrom(model);
            var sponsorTypesToUpdate = sponsorTypeService.UpdateSponsorType(sponsorTypes);
            return RedirectToAction(nameof(Index));
        }

        // GET: SponsorType/Delete/5
        public ActionResult Delete(int id)
        {
            var sponsorTypeToDelete = sponsorTypeService.GetSponsorTypeById(id);
            SponsorTypeViewModel model = new SponsorTypeViewModel();
            model.InjectFrom(sponsorTypeToDelete);
            return View(model);
        }

        // POST: SponsorType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SponsorTypeViewModel model)
        {
            SponsorTypes sponsorTypeToDelete = new SponsorTypes();
            sponsorTypeToDelete = sponsorTypeService.GetSponsorTypeById(id);
            model.InjectFrom(sponsorTypeToDelete);
            sponsorTypeService.Delete(sponsorTypeToDelete);
            sponsorTypeService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}