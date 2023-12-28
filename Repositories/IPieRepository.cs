using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories
{
    public interface IPieRepository
    {
        IEnumerable<PieDao> AllPies { get; }
        IEnumerable<PieDao> PiesOfTheWeek { get; }
        PieDao? GetPieById(int pieId);
        void CreatePie(PieDao pie);
        void UpdatePie(PieDao pie);
        void DeletePie(PieDao pie);
    }
}