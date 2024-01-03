using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        //public IActionResult Index()
        //{
        //    var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        //    var homeVieModel = new HomeViewModel(piesOfTheWeek);
        //    return View(homeVieModel);
        //}

        public IActionResult Index()
        {
            return RedirectToAction("Details", "Folder", new { id = 1 });
        }
    }
}
