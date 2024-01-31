using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManager.Api.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
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
            byte[] fileContent = Array.Empty<byte>();

            if (formFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await formFile.CopyToAsync(ms);
                fileContent = ms.ToArray();
            }

            int dotIndex = formFile.FileName.LastIndexOf('.');
            CustomFile customFile = new()
            {
                CustomFileName = formFile.FileName.Substring(0, dotIndex),
                CustomDisplayName = fileCreateView.DisplayName,
                CustomFileData = fileContent,
                CustomFileFormat = formFile.FileName.Substring(dotIndex + 1),
                ParentFolderId = fileCreateView.ParentFolderId,
                CustomFileSize = fileCreateView.FormFile.Length
            };

            _fileRepository.Add(customFile);
            _fileRepository.SaveChanges();

            return RedirectToAction("Details", "Folder", new { id = fileCreateView.ParentFolderId });
        }


        [HttpGet]
        public IActionResult FileRename(int folderId, int fileId, string folderName)
        {
            CustomFile? persistedFile = _fileRepository.GetById(fileId);
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

            CustomFile? customFile = _fileRepository.GetById(fileRenameView.FileId);
            if (customFile == null) return NotFound();
            _fileRepository.RenameFile(customFile, fileRenameView.NewFileName, fileRenameView.NewDisplayName);
            _fileRepository.SaveChanges();
            return RedirectToAction("Details", "Folder", new { id = customFile.ParentFolderId });
        }

        [HttpGet]
        public IActionResult FileDownload(int fileId)
        {
            CustomFile? file = _fileRepository.GetById(fileId);
            if (file == null || file.CustomFileData == null) return NotFound();
            // TODO add content type to the database
            return File(file.CustomFileData, "text/plain", file.CustomDisplayName + "." + file.CustomFileFormat); ;
        }

        [HttpPost]
        public IActionResult FileDelete(int fileId)
        {
            CustomFile? customFile = _fileRepository.GetById(fileId);
            if (customFile == null) return NotFound();
            _fileRepository.Delete(customFile);
            _fileRepository.SaveChanges();
            return RedirectToAction("Details", "Folder", new { id = customFile.ParentFolderId });
        }
    }
}
