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
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService workshopService;
        public WorkshopsController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        [Area("Admin")]
        // GET: Workshops
        public ActionResult Index()
        {
            IEnumerable<Workshops> allWorkshops = workshopService.GetAllWorkshops();
            return View(allWorkshops);
        }

        [Area("Admin")]
        // GET: Workshops/Details/5
        public ActionResult Details(int id)
        {
            Workshops workshops = workshopService.GetWorkshopById(id);
            WorkshopViewModel model = new WorkshopViewModel();
            model.InjectFrom(workshops);
            return View(workshops);
        }

        [Area("Admin")]
        // GET: Workshops/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Workshops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkshopViewModel model)
        {
            if (ModelState.IsValid)
            {
                Workshops workshop = new Workshops();
                workshop.InjectFrom(model);
                var createNewWorkshop = workshopService.AddWorkshop(workshop);
                if (createNewWorkshop == null)
                {
                    ModelState.AddModelError("Name", "The Name must be unique!");

                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Workshops/Edit/5
        public ActionResult Edit(int id)
        {
            var workshop = workshopService.GetWorkshopById(id);
            WorkshopViewModel model = new WorkshopViewModel();
            model.InjectFrom(workshop);
            return View(model);
        }


        [Area("Admin")]
        // POST: Workshops/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkshopViewModel model)
        {
            Workshops workshop = new Workshops();
            workshop.InjectFrom(model);
            var workshopToUpdate = workshopService.UpdateWorkshop(workshop);
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Workshops/Delete/5
        public ActionResult Delete(int id)
        {
            var workshopToDelete = workshopService.GetWorkshopById(id);
            WorkshopViewModel model = new WorkshopViewModel();
            model.InjectFrom(workshopToDelete);
            return View(model);
        }

        [Area("Admin")]
        // POST: Workshops/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WorkshopViewModel model)
        {
            Workshops workshopToDelete = new Workshops();
            workshopToDelete = workshopService.GetWorkshopById(id);
            model.InjectFrom(workshopToDelete);
            workshopService.Delete(workshopToDelete);
            workshopService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}