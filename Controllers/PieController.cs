using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
         private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            PieListModel pieListModel = new PieListModel
            (_pieRepository.AllPies, "Cheese cakes");
            return View(pieListModel);
        }
    }
}