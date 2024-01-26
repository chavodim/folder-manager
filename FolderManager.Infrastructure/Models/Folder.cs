using System.Collections.Generic;

namespace FolderManagerApp.Models
{
    public class Folder
    {
        public int FolderId { get; set; }

        public string FolderName { get; set; } = string.Empty;

        public List<CustomFile>? Files { get; set; }

        public string FolderPath { get; set; } = string.Empty;

        public int? ParentFolderId { get; set; }

        public Folder? ParentFolder { get; set; }

        public List<Folder>? ChildrenFolders { get; set; }

        public string FolderPathWithoutRoot()
        {
            int firstIndexOfSlash = FolderPath.IndexOf(@"\");

            if (firstIndexOfSlash == -1)
            {
                return "";
            }
            return FolderPath.Substring(firstIndexOfSlash);
        }


    }
}