using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {        
        public FolderDao CurrentFolder;

        public List<CustomFileDao>? CustomFiles;

        public List<FolderDao>? ChildrenFolders;

        public List<FolderDao>? ParentFolders;

        public FileListModel(FolderDao currentFolder, List<CustomFileDao>? customFiles, List<FolderDao>? childrenFolders, List<FolderDao>? parentFolders)
        {
            CurrentFolder = currentFolder;
            CustomFiles = customFiles;
            ChildrenFolders = childrenFolders;
            ParentFolders = parentFolders;
        }
    }
}