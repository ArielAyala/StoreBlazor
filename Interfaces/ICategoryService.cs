namespace StoreBlazor;

public interface ICategoryService
{
    Task<List<Category>?> GetCategories();
}