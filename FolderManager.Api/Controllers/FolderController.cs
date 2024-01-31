using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// TODO - delete folder with other folders in it
// TODO - Make a query to get the breadcrumbs of a Folder without saving the path
// TODO - Add folder validation for the same name  fluent validation
// TODO - Separate Commands and Queries
// TODO - Add MediatR and implement it

namespace FolderManagerApp.Controllers
{
    public class FolderController : Controller
    {
        private readonly IFolderRepository _folderRepository;

        public FolderController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Folder? persistedFolder = _folderRepository.GetFolderByIdWithFiles(id);
            if (persistedFolder == null)
            {
                return NotFound();
            }
            List<string> folderNames = persistedFolder.FolderPath.Split(@"\").ToList();

            List<Folder> parentFolders = new();

            folderNames.ForEach(name =>
            {
                Folder? folderDao = _folderRepository.Find(folder => folder.FolderName.ToLower().Equals(name)).First();
                if (folderDao != null)
                {
                    parentFolders.Add(folderDao);
                }
            });

            List<Folder>? childrenFolders = _folderRepository.GetChildrenFolders(id);
            FileListModel fileListModel = new(persistedFolder, persistedFolder.Files, childrenFolders, parentFolders);
            return View(fileListModel);
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

            Folder? parentFolder = _folderRepository.GetById(folderCreateView.ParentFolderId);

            Folder folder = new() 
            {
                FolderName = folderCreateView.FolderName,
                FolderPath = parentFolder.FolderPath + @"\" + folderCreateView.FolderName,
                ParentFolderId = folderCreateView.ParentFolderId,

            };
            _folderRepository.Add(folder);
            _folderRepository.SaveChanges();
            return RedirectToAction("Details", new { id = folderCreateView.ParentFolderId });
        }

        [HttpGet]
        public IActionResult FolderRename(int parentFolderId, int folderId, string parentFolderName)
        {
            Folder? persistedFolder = _folderRepository.GetById(folderId);
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
            Folder? folderDao = _folderRepository.GetById(folderRenameView.FolderId);
            if (folderDao == null) return NotFound();
            _folderRepository.RenameFolder(folderDao, folderRenameView.NewName);
            _folderRepository.SaveChanges();
            return RedirectToAction("Details", new { id = folderRenameView.ParentFolderId });
        }

        [HttpPost]
        public IActionResult FolderDelete(int parentFolderId, int folderId)
        {
            Folder? folder = _folderRepository.GetById(folderId);
            if (folder == null) return NotFound();
            _folderRepository.Delete(folder);
            _folderRepository.SaveChanges();
            return RedirectToAction("Details", new { id = parentFolderId });
        }
    }
}