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
            List<string> folderNames = persistedFolder.FolderPath.Split(@"\").ToList();

            List<FolderDao> parentFolders = new();

            folderNames.ForEach(name =>
            {
                FolderDao? folderDao = _folderRepository.GetFolderByName(name);
                if (folderDao != null)
                {
                    parentFolders.Add(folderDao);
                }
            });

            List<CustomFileDao>? files = _fileRepository.GetFilesByFolderId(persistedFolder.FolderId);
            List<FolderDao>? childrenFolders = _folderRepository.GetChildrenFolders(id);
            FileListModel fileListModel = new(persistedFolder, files, childrenFolders, parentFolders);
            return View(fileListModel);
        }

        public IActionResult CreateFile(int folderId, string folderName)
        {
            FileCreateView FileCreateView = new()
            {
                FolderId = folderId,
                FolderName = folderName
            };
            return View(FileCreateView);
        }

        //TODO exe, zip files cannot be saves

        [HttpPost]
        [RequestSizeLimit(1_000_000)]
        public async Task<IActionResult> CreateFile(FileCreateView fileCreateView)
        {
            if (!ModelState.IsValid) return View(fileCreateView);

            IFormFile formFile = fileCreateView.FormFile;
            FolderDao? folderDao = _folderRepository.GetFolderById(fileCreateView.FolderId);
            string filePath = _webHostEnvironment.WebRootPath + folderDao?.FolderPathWithoutRoot() + @"\" + formFile.FileName;
            byte[] fileContent = Array.Empty<byte>();

            if (formFile.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);

                }
                using var ms = new MemoryStream();
                await formFile.CopyToAsync(ms);
                fileContent = ms.ToArray();
            }

            int dotIndex = formFile.FileName.LastIndexOf('.');
            CustomFileDao customFileDao = new()
            {
                CustomFileName = formFile.FileName.Substring(0, dotIndex),
                CustomDisplayName = fileCreateView.DisplayName,
                CustomFileData = fileContent,
                CustomFileFormat = formFile.FileName.Substring(dotIndex + 1),
                ParentFolderId = fileCreateView.FolderId,
                CustomFileSize = fileCreateView.FormFile.Length
            };

            _fileRepository.SaveFile(customFileDao);

            return RedirectToAction("Details", new { id = fileCreateView.FolderId });
        }

        public IActionResult CreateFolder(int currentFolderId, string currentFolderName)
        {
            FolderCreateView folderCreateView = new()
            {
                CurrentFolderId = currentFolderId,
                CurrentFolderName = currentFolderName
            };
            return View(folderCreateView);
        }

        [HttpPost]
        public IActionResult CreateFolder(FolderCreateView folderCreateView)
        {
            if (!ModelState.IsValid) return View(folderCreateView);

            FolderDao? parentFolder = _folderRepository.GetFolderById(folderCreateView.CurrentFolderId);
            string newFolderPath = _webHostEnvironment.WebRootPath + parentFolder.FolderPathWithoutRoot();
            DirectoryInfo directory = new DirectoryInfo(newFolderPath);
            directory.CreateSubdirectory(folderCreateView.FolderName);

            FolderDao folderDao = new FolderDao
            {
                FolderName = folderCreateView.FolderName,
                FolderPath = parentFolder.FolderPath + @"\" + folderCreateView.FolderName,
                ParentFolderId = folderCreateView.CurrentFolderId,

            };
            _folderRepository.CreateFolder(folderDao);
            return RedirectToAction("Details", new { id = folderCreateView.CurrentFolderId });
        }

        public IActionResult FileRenameForm(int folderId, int fileId)
        {
            CustomFileDao? persistedFile = _fileRepository.GetFileById(fileId);
            if (persistedFile == null) return NotFound();
            FileRenameView fileRenameView = new FileRenameView
            {
                FileId = fileId,
                NewFileName = persistedFile.CustomFileName,
                NewDisplayName = persistedFile.CustomDisplayName,
                FolderId = folderId
            };
            return View(fileRenameView);
        }

        [HttpPost]
        public IActionResult RenameFile(FileRenameView fileRenameView)
        {
            CustomFileDao? customFileDao = _fileRepository.GetFileById(fileRenameView.FileId);
            if (customFileDao == null) return NotFound();
            string filepath = _webHostEnvironment.WebRootPath + customFileDao.CustomFilePath;
            string newFilePath = filepath.Replace(customFileDao.CustomFileName, fileRenameView.NewFileName);
            System.IO.File.Move(filepath, newFilePath);

            _fileRepository.RenameFile(customFileDao, fileRenameView.NewFileName, fileRenameView.NewDisplayName);
            return RedirectToAction("Details", new { id = customFileDao.ParentFolderId });
        }

        public IActionResult FolderRenameForm(int parentFolderId, int folderId)
        {
            FolderDao? persistedFolder = _folderRepository.GetFolderById(folderId);
            if (persistedFolder == null) return NotFound();
            FolderRenameView folderRenameView = new FolderRenameView
            {
                FolderId = folderId,
                NewName = persistedFolder.FolderName,
                ParentFolderId = parentFolderId
            };
            return View(folderRenameView);
        }

        [HttpPost]
        public IActionResult RenameFolder(FolderRenameView folderRenameView)
        {
            FolderDao? folderDao = _folderRepository.GetFolderById(folderRenameView.FolderId);
            if (folderDao == null) return NotFound();
            string folderPath = _webHostEnvironment.WebRootPath + folderDao.FolderPathWithoutRoot();
            string newFolderPath = folderPath.Replace(folderDao.FolderName, folderRenameView.NewName);
            Directory.Move(folderPath, newFolderPath);
            _folderRepository.RenameFolder(folderDao, folderRenameView.NewName);
            return RedirectToAction("Details", new { id = folderRenameView.ParentFolderId });
        }

        [HttpPost]
        public IActionResult DeleteFile(int fileId)
        {
            CustomFileDao? customFileDao = _fileRepository.GetFileById(fileId);
            if (customFileDao == null) return NotFound();
            string fullFilePath = _webHostEnvironment.WebRootPath + customFileDao.CustomFilePath;

            System.IO.File.Delete(fullFilePath);

            _fileRepository.DeleteFile(customFileDao);
            return RedirectToAction("Details", new { id = customFileDao.ParentFolderId });
        }

        [HttpPost]
        public IActionResult DeleteFolder(int parentFolderId, int folderId)
        {
            FolderDao? folderDao = _folderRepository.GetFolderById(folderId);
            if (folderDao == null) return NotFound();
            string folderPath = _webHostEnvironment.WebRootPath + folderDao.FolderPathWithoutRoot();

            Directory.Delete(folderPath, true);
            _folderRepository.DeleteFolder(folderId, folderPath);
            return RedirectToAction("Details", new { id = parentFolderId });
        }
    }
}