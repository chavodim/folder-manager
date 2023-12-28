using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {        
        public FolderDao Folder;

        public List<CustomFileDao>? CustomFiles;

        public FileListModel(FolderDao folder, List<CustomFileDao>? customFiles)
        {
            Folder = folder;
            CustomFiles = customFiles;
        }
    }
}