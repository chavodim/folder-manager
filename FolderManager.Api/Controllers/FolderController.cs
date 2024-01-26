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

        public FolderController(IFolderRepository folderRepository, IFileRepository fileRepository)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public IActionResult Details(int id)
        {
            Folder? persistedFolder = _folderRepository.GetFolderById(id);
            if (persistedFolder == null)
            {
                return NotFound();
            }
            List<string> folderNames = persistedFolder.FolderPath.Split(@"\").ToList();

            List<Folder> parentFolders = new();

            folderNames.ForEach(name =>
            {
                Folder? folderDao = _folderRepository.GetFolderByName(name);
                if (folderDao != null)
                {
                    parentFolders.Add(folderDao);
                }
            });

            List<CustomFile>? files = _fileRepository.GetFilesByFolderId(persistedFolder.FolderId);
            List<Folder>? childrenFolders = _folderRepository.GetChildrenFolders(id);
            FileListModel fileListModel = new(persistedFolder, files, childrenFolders, parentFolders);
            return View(fileListModel);
        }

        public IActionResult FileCreate(int folderId, string folderName)
        {
            FileCreateView FileCreateView = new()
            {
                ParentFolderId = folderId,
                ParentFolderName = folderName
            };
            return View(FileCreateView);
        }

        [HttpPost]
        [RequestSizeLimit(1_000_000)]
        public async Task<IActionResult> FileCreate(FileCreateView fileCreateView)
        {
            if (!ModelState.IsValid) return View(fileCreateView);

            IFormFile formFile = fileCreateView.FormFile;
            Folder? folderDao = _folderRepository.GetFolderById(fileCreateView.ParentFolderId);
            byte[] fileContent = Array.Empty<byte>();

            if (formFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await formFile.CopyToAsync(ms);
                fileContent = ms.ToArray();
            }

            int dotIndex = formFile.FileName.LastIndexOf('.');
            CustomFile customFileDao = new()
            {
                CustomFileName = formFile.FileName.Substring(0, dotIndex),
                CustomDisplayName = fileCreateView.DisplayName,
                CustomFileData = fileContent,
                CustomFileFormat = formFile.FileName.Substring(dotIndex + 1),
                ParentFolderId = fileCreateView.ParentFolderId,
                CustomFileSize = fileCreateView.FormFile.Length
            };

            _fileRepository.SaveFile(customFileDao);

            return RedirectToAction("Details", new { id = fileCreateView.ParentFolderId });
        }

        [HttpGet]
        public IActionResult FolderCreate(int currentFolderId, string currentFolderName)
        {
            FolderCreateView folderCreateView = new()
            {
                ParentFolderId = currentFolderId,
                ParentFolderName = currentFolderName
            };
            return View(folderCreateView);
        }

        [HttpPost]
        public IActionResult FolderCreate(FolderCreateView folderCreateView)
        {
            if (!ModelState.IsValid) return View(folderCreateView);

            Folder? parentFolder = _folderRepository.GetFolderById(folderCreateView.ParentFolderId);

            Folder folderDao = new() 
            {
                FolderName = folderCreateView.FolderName,
                FolderPath = parentFolder.FolderPath + @"\" + folderCreateView.FolderName,
                ParentFolderId = folderCreateView.ParentFolderId,

            };
            _folderRepository.CreateFolder(folderDao);
            return RedirectToAction("Details", new { id = folderCreateView.ParentFolderId });
        }

        [HttpGet]
        public IActionResult FileRename(int folderId, int fileId, string folderName)
        {
            CustomFile? persistedFile = _fileRepository.GetFileById(fileId);
            if (persistedFile == null) return NotFound();
            FileRenameView fileRenameView = new()
            {
                FileId = fileId,
                NewFileName = persistedFile.CustomFileName,
                NewDisplayName = persistedFile.CustomDisplayName,
                ParentFolderId = folderId,
                ParentFolderName = folderName
            };
            return View(fileRenameView);
        }

        [HttpPost]
        public IActionResult FileRename(FileRenameView fileRenameView)
        {
            if (!ModelState.IsValid) { return View(fileRenameView); };

            CustomFile? customFileDao = _fileRepository.GetFileById(fileRenameView.FileId);
            if (customFileDao == null) return NotFound();
            _fileRepository.RenameFile(customFileDao, fileRenameView.NewFileName, fileRenameView.NewDisplayName);
            return RedirectToAction("Details", new { id = customFileDao.ParentFolderId });
        }

        public IActionResult FolderRename(int parentFolderId, int folderId, string parentFolderName)
        {
            Folder? persistedFolder = _folderRepository.GetFolderById(folderId);
            if (persistedFolder == null) return NotFound();
            FolderRenameView folderRenameView = new FolderRenameView
            {
                FolderId = folderId,
                NewName = persistedFolder.FolderName,
                ParentFolderId = parentFolderId,
                ParentFolderName = parentFolderName
            };
            return View(folderRenameView);
        }

        [HttpPost]
        public IActionResult FolderRename(FolderRenameView folderRenameView)
        {
            Folder? folderDao = _folderRepository.GetFolderById(folderRenameView.FolderId);
            if (folderDao == null) return NotFound();
            _folderRepository.RenameFolder(folderDao, folderRenameView.NewName);
            return RedirectToAction("Details", new { id = folderRenameView.ParentFolderId });
        }

        public IActionResult FileDownload(int fileId)
        {
            CustomFile? file = _fileRepository.GetFileById(fileId);
            if (file == null || file.CustomFileData == null) return NotFound();
            // TODO add content type to the database
            return File(file.CustomFileData, "text/plain", file.CustomDisplayName + "." + file.CustomFileFormat); ;
        }

        [HttpPost]
        public IActionResult FileDelete(int fileId)
        {
            CustomFile? customFileDao = _fileRepository.GetFileById(fileId);
            if (customFileDao == null) return NotFound();
            _fileRepository.DeleteFile(customFileDao);
            return RedirectToAction("Details", new { id = customFileDao.ParentFolderId });
        }

        [HttpPost]
        public IActionResult FolderDelete(int parentFolderId, int folderId)
        {
            Folder? folderDao = _folderRepository.GetFolderById(folderId);
            if (folderDao == null) return NotFound();
            _folderRepository.DeleteFolder(folderId);
            return RedirectToAction("Details", new { id = parentFolderId });
        }
    }
}