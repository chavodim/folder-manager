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
            List<string> folderNames = persistedFolder.FolderPath.Split('/').ToList();

            List<FolderDao> parentFolders = new List<FolderDao>();

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

        public IActionResult CreateFileForm(int folderId)
        {
            FileCreateView FileCreateView = new FileCreateView();
            FileCreateView.FolderId = folderId;
            return View(FileCreateView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile(FileCreateView fileCreateView)
        {
            IFormFile formFile = fileCreateView.FormFile;
            string filePath = _webHostEnvironment.WebRootPath + "/" + formFile.FileName;
            byte[] fileContent = new byte[0];

            if (formFile.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    
                }
                using (var ms = new MemoryStream())
                {
                    await formFile.CopyToAsync(ms);
                    fileContent = ms.ToArray();
                }
            }

            int dotIndex = formFile.FileName.LastIndexOf('.');
            CustomFileDao customFileDao = new()
            {
                CustomFileName = formFile.FileName.Substring(0, dotIndex),
                CustomFileData = fileContent,
                CustomFileFormat = formFile.FileName.Substring(dotIndex + 1),
                ParentFolderId = fileCreateView.FolderId
            };

            _fileRepository.SaveFile(customFileDao);

            return RedirectToAction("Details", new { id = fileCreateView.FolderId });
        }

        public IActionResult CreateFolderForm(int folderId)
        {
            FolderCreateView folderCreateView = new FolderCreateView
            {
                FolderId = folderId 
            };
            return View(folderCreateView);
        }

        [HttpPost]
        public IActionResult CreateFolder(FolderCreateView folderCreateView)
        {
            FolderDao? parentFolder = _folderRepository.GetFolderById(folderCreateView.FolderId);
            string newFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, parentFolder.FolderPathWithoutRoot());
            DirectoryInfo directory = new DirectoryInfo(newFolderPath);
            directory.CreateSubdirectory(folderCreateView.FolderName);

            FolderDao folderDao = new FolderDao
            {
                FolderName = folderCreateView.FolderName,
                FolderPath = parentFolder.FolderPath + "/" + folderCreateView.FolderName,
                ParentFolderId = folderCreateView.FolderId,

            };
            _folderRepository.CreateFolder(folderDao);
            return RedirectToAction("Details", new { id = folderCreateView.FolderId });
        }

        [HttpPost]
        public IActionResult DeleteFile(int folderId, int fileId)
        {
            _fileRepository.DeleteFile(fileId);
            return RedirectToAction("Details", new { id = folderId });
        }

        [HttpPost]
        public IActionResult DeleteFolder(int parentFolderId, int folderId)
        {
            _folderRepository.DeleteFolder(folderId);
            return RedirectToAction("Details", new { id = parentFolderId });
        }
    }
}