using FolderManager.Infrastructure.Repositories;
using FolderManagerApp.Models;
using System.Collections.Generic;

namespace FolderManagerApp.Repositories
{
    public interface IFileRepository : IRepository<CustomFile>
    {
        void RenameFile(CustomFile customFileDao, string newFileName, string newDisplayName);
    }
}
