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
    public class SponsorsController : Controller
    {
        private readonly ISponsorService sponsorService;
        public SponsorsController(ISponsorService sponsorService)
        {
            this.sponsorService = sponsorService;
        }



        [Area("Admin")]
        // GET: Sponsors
        public ActionResult Index()
        {
            IEnumerable<Sponsors> allSponsors = sponsorService.GetAllSponsors();
            return View(allSponsors);
        }

        [Area("Admin")]
        // GET: Sponsors/Details/5
        public ActionResult Details(int id)
        {
            Sponsors sponsor = sponsorService.GetSponsorById(id);
            SponsorsViewModel model = new SponsorsViewModel();
            model.InjectFrom(sponsor);
            return View(sponsor);
        }

        [Area("Admin")]
        // GET: Sponsors/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Sponsors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Sponsors sponsor = new Sponsors();

                sponsor.InjectFrom(model);

                var createNewSponsor = sponsorService.AddSponsor(sponsor);

                if (createNewSponsor == null)
                {
                    ModelState.AddModelError("Name", "The Name must be unique!");

                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Sponsors/Edit/5
        public ActionResult Edit(int id)
        {
            var sponsor = sponsorService.GetSponsorById(id);
            SponsorsViewModel model = new SponsorsViewModel();
            model.InjectFrom(sponsor);
            return View(model);
        }

        [Area("Admin")]
        // POST: Sponsors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SponsorsViewModel model)
        {
            Sponsors sponsor = new Sponsors();
            sponsor.InjectFrom(model);
            var sponsorToUpdate = sponsorService.UpdateSponsor(sponsor);
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Sponsors/Delete/5
        public ActionResult Delete(int id)
        {
            var sponsorToDelete = sponsorService.GetSponsorById(id);
            SponsorsViewModel model = new SponsorsViewModel();
            model.InjectFrom(sponsorToDelete);
            return View(model);
        }

        [Area("Admin")]
        // POST: Sponsors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SponsorsViewModel model)
        {
            Sponsors sponsorToDelete = new Sponsors();
            sponsorToDelete = sponsorService.GetSponsorById(id);
            model.InjectFrom(sponsorToDelete);
            sponsorService.Delete(sponsorToDelete);
            sponsorService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}