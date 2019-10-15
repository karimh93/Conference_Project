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
    public class EditionsController : Controller
    {
        private readonly IEditionService editionService;
        public EditionsController(IEditionService editionService)
        {
            this.editionService = editionService;
        }



        [Area("Admin")]
        // GET: Editions
        public ActionResult Index()
        {
            IEnumerable<Editions> allEditions = editionService.GetAllEditions();
            return View(allEditions);
        }

        [Area("Admin")]
        // GET: Editions/Details/5
        public ActionResult Details(int id)
        {
            Editions editions = editionService.GetEditionById(id);
            EditionViewModel model = new EditionViewModel();
            model.InjectFrom(editions);
            return View(editions);
        }

        [Area("Admin")]
        // GET: Editions/Create
        public ActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        // POST: Editions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Editions edition = new Editions();

                edition.InjectFrom(model);

                var createNewEdition = editionService.AddEdition(edition);

                if (createNewEdition == null)
                {
                    ModelState.AddModelError("Name", "The Name must be unique!");

                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Editions/Edit/5
        public ActionResult Edit(int id)
        {
            var edition = editionService.GetEditionById(id);
            EditionViewModel model = new EditionViewModel();
            model.InjectFrom(edition);
            return View(model);
        }

        [Area("Admin")]
        // POST: Editions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditionViewModel model)
        {
            Editions edition = new Editions();
            edition.InjectFrom(model);
            var editionToUpdate = editionService.UpdateEdition(edition);
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        // GET: Editions/Delete/5
        public ActionResult Delete(int id)
        {
            var editionToDelete = editionService.GetEditionById(id);
            EditionViewModel model = new EditionViewModel();
            model.InjectFrom(editionToDelete);
            return View(model);
        }

        [Area("Admin")]
        // POST: Editions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditionViewModel model)
        {
            Editions editionToDelete = new Editions();
            editionToDelete = editionService.GetEditionById(id);
            model.InjectFrom(editionToDelete);
            editionService.Delete(editionToDelete);
            editionService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}