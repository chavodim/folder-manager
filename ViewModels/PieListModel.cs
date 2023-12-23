using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class PieListModel
    {

        public IEnumerable<Pie> Pies { get; set; }

        public string? CurrentCategory { get; set; }

        public PieListModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies;
            currentCategory = CurrentCategory;
        }
        
    }
}