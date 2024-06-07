using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FlashcardWebApp.Interface;
using FlashcardWebApp.Models;
using FlashcardWebApp.Utilities;

namespace FlashcardWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudySetService _StudySetService;

        public HomeController(IStudySetService studySetService)
        {
            _StudySetService = studySetService;
        }

        public async Task<IActionResult> Index()
        {
            var studySetCount = HttpContext.Items["StudySetCount"] as int?;
            ViewBag.StudySetCount = studySetCount ?? 0;
            List<StudySet> studySets = await _StudySetService.GetAllStudySets();
            ColorManager.AssignUniqueColor(studySets, HttpContext);

            return View(studySets);
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
