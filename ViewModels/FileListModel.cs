using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class FileListModel
    {
        
        public string Root;
        
        public IEnumerable<CustomFile> Files { get; set; }

        public FileListModel(IEnumerable<CustomFile> files, string root)
        {
            Files = files;
            Root = root;
        }
    }
}