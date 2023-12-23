namespace FolderManagerApp.Models.Repositories

{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
        Category? GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
