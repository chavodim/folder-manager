using FolderManagerApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFolderRepository _folderRepository;
        
        public HomeController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public IActionResult Index()
        {
            int? rootId = _folderRepository.GetFolderByName("root")?.FolderId;
            return RedirectToAction("Details", "Folder", new { id = rootId });
        }
    }
}
