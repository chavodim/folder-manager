using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {        
        public Folder CurrentFolder;

        public List<CustomFile>? CustomFiles;

        public List<Folder>? ChildrenFolders;

        public List<Folder>? ParentFolders;

        public FileListModel(Folder currentFolder, List<CustomFile>? customFiles, List<Folder>? childrenFolders, List<Folder>? parentFolders)
        {
            CurrentFolder = currentFolder;
            CustomFiles = customFiles;
            ChildrenFolders = childrenFolders;
            ParentFolders = parentFolders;
        }
    }
}