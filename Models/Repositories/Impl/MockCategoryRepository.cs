namespace FolderManagerApp.Models.Repositories.Impl
{
    public class MockCategoryRepository : ICategoryRepository
    {

        public IEnumerable<Category> GetAllCategories =>
            new List<Category>
            {
                new() { CategoryId = 1, CategoryName = "Category 1" },
                new() { CategoryId = 2, CategoryName = "Category 2" },
                new() { CategoryId = 3, CategoryName = "Category 3" }
            };

        public Category? GetCategoryById(int id) 
        {
            return GetAllCategories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            GetAllCategories.Append(category);
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = GetAllCategories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
            }
        }

        public void DeleteCategory(int id)
        {
            var categoryToRemove = GetAllCategories.Where(c => c.CategoryId == id);
        }
    }
}
