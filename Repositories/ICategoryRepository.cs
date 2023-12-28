using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories

{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDao> GetAllCategories { get; }
        CategoryDao? GetCategoryById(int id);
        void AddCategory(CategoryDao category);
        void UpdateCategory(CategoryDao category);
        void DeleteCategory(int id);
    }
}
