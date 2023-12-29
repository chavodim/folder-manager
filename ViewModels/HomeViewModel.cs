using FolderManagerApp.Models;

namespace FolderManagerApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PieDao> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<PieDao> pieDaos) 
        {
            PiesOfTheWeek = pieDaos;
        }
    }
}
