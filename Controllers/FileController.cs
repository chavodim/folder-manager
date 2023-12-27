using FolderManagerApp.Models;
using FolderManagerApp.Models.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFolderRepository _folderRepository;

        public FileController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public IActionResult List()
        {
            Folder? persistedFolder = _folderRepository.GetFolderById(1);
            if (persistedFolder != null)
            {
                FileListModel fileListModel = new(persistedFolder);
                return View(fileListModel);
            }
            return null;
        }
    }
}