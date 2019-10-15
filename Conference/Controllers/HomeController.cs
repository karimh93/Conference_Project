using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conference.Models;
using Conference.Service;
using Conference.Domain.Entities;

namespace Conference.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpeakerService speakerService;
        private readonly IWorkshopService workshopService;
        private readonly ITalkService talkService;

        public HomeController(ISpeakerService speakerService, IWorkshopService workshopService, ITalkService talkService)
        {
            this.speakerService = speakerService;
            this.workshopService = workshopService;
            this.talkService = talkService;

        }

        public IActionResult Index()
        {
            IEnumerable<Speakers> allSpeakers = speakerService.GetAllSpeakers();
            IEnumerable<Workshops> allWorkshops = workshopService.GetAllWorkshops();
            IEnumerable<Talks> allTalks = talkService.GetAllTalks();
            return View(allSpeakers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
