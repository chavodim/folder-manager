using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class FolderController : Controller
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FolderController(IFolderRepository folderRepository, IFileRepository fileRepository, IWebHostEnvironment webHostEnvironment)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Details(int id)
        {
            FolderDao? persistedFolder = _folderRepository.GetFolderById(id);
            if (persistedFolder == null)
            {
                return NotFound();
            }

            List<FolderDao> parentFolders = new List<FolderDao>();
            
            List<string> folderNames = persistedFolder.FolderPath.Split('/').ToList();
            folderNames.ForEach(name =>
            {
                FolderDao? folderDao = _folderRepository.GetFolderByName(name);
                if (folderDao != null)
                {
                    parentFolders.Add(folderDao);
                }
            });
            Console.WriteLine(folderNames[0]);


            List<CustomFileDao>? files = _fileRepository.GetFilesByFolderId(persistedFolder.FolderId);
            List<FolderDao>? childrenFolders = _folderRepository.GetChildrenFolders(id);
            //DirectoryInfo directory = new DirectoryInfo(_webHostEnvironment.ContentRootPath);
            //directory.CreateSubdirectory(directory.FullName);
            
            FileListModel fileListModel = new(persistedFolder, files, childrenFolders, parentFolders);
            return View(fileListModel);
        }
    }
}