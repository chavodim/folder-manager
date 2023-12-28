using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {        
        public FolderDao Folder;

        public FileListModel(FolderDao folder)
        {
            Folder = folder;
        }
    }
}