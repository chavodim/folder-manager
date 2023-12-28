using FolderManagerApp.Data;
using FolderManagerApp.Models;
using FolderManagerApp.Repositories;

namespace FolderManagerApp.Repositories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public CategoryRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<CategoryDao> GetAllCategories
        {
            get
            {
                return _folderManagerDbContext.Categories;
            }
        }

        public void AddCategory(CategoryDao category)
        {
            _folderManagerDbContext.Categories.Add(category);
            _folderManagerDbContext.SaveChanges();
        }

        public CategoryDao? GetCategoryById(int id)
        {
            return _folderManagerDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void DeleteCategory(int id)
        {
            var persistedCategory = GetCategoryById(id);
            if (persistedCategory != null)
            {
                _folderManagerDbContext.Remove(persistedCategory);
                _folderManagerDbContext.SaveChanges();
            }
        }

        public void UpdateCategory(CategoryDao category)
        {
            var persistedCategory = GetCategoryById(category.CategoryId);
            if (persistedCategory != null)
            {
                _folderManagerDbContext.Remove(persistedCategory);
                _folderManagerDbContext.SaveChanges();
            }
        }

    }
}