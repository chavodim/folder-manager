
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Models.Repositories.Impl
{
    public class PieRepository : IPieRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public PieRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _folderManagerDbContext.Pies.Include(p => p.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _folderManagerDbContext.Pies
                .Include(p => p.Category)
                .Where(p => p.IsPieOfTheWeek);
            }
        }


        public Pie? GetPieById(int pieId)
        {
            return _folderManagerDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }


        public void CreatePie(Pie pie)
        {
            _folderManagerDbContext.Pies.Add(pie);
            _folderManagerDbContext.SaveChanges();
        }

        public void DeletePie(Pie pie)
        {
            var persistedPie = GetPieById(pie.PieId);
            if (persistedPie != null)
            {
            _folderManagerDbContext.Remove(persistedPie);
            _folderManagerDbContext.SaveChanges();
            }
        }

        public void UpdatePie(Pie pie)
        {
            var persistedPie = GetPieById(pie.PieId);
            if (persistedPie != null)
            {
                persistedPie.Name = pie.Name;
                persistedPie.ShortDescription = pie.ShortDescription;
                persistedPie.Price = pie.Price;
                persistedPie.IsPieOfTheWeek = pie.IsPieOfTheWeek;

                _folderManagerDbContext.SaveChanges();
            }
        }
    }
}