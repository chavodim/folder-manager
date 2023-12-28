using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;

        public FileController(IFolderRepository folderRepository, IFileRepository fileRepository)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public IActionResult List()
        {
            FolderDao? persistedFolder = _folderRepository.GetFolderById(1);
            List<CustomFileDao>? files = _fileRepository.GetFilesByFolderId(persistedFolder.FolderId);
            if (persistedFolder != null)
            {
                FileListModel fileListModel = new(persistedFolder, files);
                return View(fileListModel);
            }
            return null;
        }
    }
}