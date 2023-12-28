using FolderManagerApp.Data;
using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class PieRepository : IPieRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public PieRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<PieDao> AllPies
        {
            get
            {
                return _folderManagerDbContext.Pies.Include(p => p.Category);
            }
        }

        public IEnumerable<PieDao> PiesOfTheWeek
        {
            get
            {
                return _folderManagerDbContext.Pies
                .Include(p => p.Category)
                .Where(p => p.IsPieOfTheWeek);
            }
        }


        public PieDao? GetPieById(int pieId)
        {
            return _folderManagerDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }


        public void CreatePie(PieDao pie)
        {
            _folderManagerDbContext.Pies.Add(pie);
            _folderManagerDbContext.SaveChanges();
        }

        public void DeletePie(PieDao pie)
        {
            var persistedPie = GetPieById(pie.PieId);
            if (persistedPie != null)
            {
                _folderManagerDbContext.Remove(persistedPie);
                _folderManagerDbContext.SaveChanges();
            }
        }

        public void UpdatePie(PieDao pie)
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