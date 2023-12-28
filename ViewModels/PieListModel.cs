using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class PieListModel
    {

        public IEnumerable<PieDao> Pies { get; set; }

        public string? CurrentCategory { get; set; }

        public PieListModel(IEnumerable<PieDao> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
        
    }
}