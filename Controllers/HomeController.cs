using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Details", "Folder", new { id = 1 });
        }
    }
}
