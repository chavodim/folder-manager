using FolderManager.Infrastructure.Repositories.Impl;
using FolderManagerApp.Data;
using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class FileRepository : GenericRepository<CustomFile>, IFileRepository
    {

        public FileRepository(FolderManagerDbContext folderManagerDbContext) : base(folderManagerDbContext)
        {
        }

        public override IEnumerable<CustomFile> All
        {
            get
            {
                return folderManagerDbContext.Set<CustomFile>().Include(f => f.ParentFolder);
            }
        }

        public void RenameFile(CustomFile customFileDao, string newFileName,string newDisplayName)
        {
            customFileDao.CustomFileName = newFileName;
            customFileDao.CustomDisplayName = newDisplayName;
            base.Update(customFileDao);
        }
    }
}