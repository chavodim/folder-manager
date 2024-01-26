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
            int? rootId = _folderRepository.Find(folder => folder.FolderName.ToLower().Equals("root")).First().FolderId;
            return RedirectToAction("Details", "Folder", new { id = rootId });
        }
    }
}
