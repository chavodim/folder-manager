using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {        
        public Folder Folder;

        public FileListModel(Folder folder)
        {
            Folder = folder;
        }
    }
}