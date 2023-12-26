using FolderManagerApp.Models.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public IActionResult List()
        {
            FileListModel fileListModel = new(_fileRepository.Folder);
            return View(fileListModel);
        }
    }
}