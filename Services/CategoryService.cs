using System.Net.Http.Json;
using System.Text.Json;

namespace StoreBlazor;

public class CategoryService : ICategoryService
{
    public readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public CategoryService(HttpClient httpClient, JsonSerializerOptions options)
    {
        _client = httpClient;
        _options = options;
    }

    public async Task<List<Category>?> GetCategories()
    {
        var response = await _client.GetAsync("/v1/categories");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<List<Category>>(content, _options);
    }

    public async Task AddCategory(Category category)
    {
        var response = await _client.PostAsync("/v1/categories", JsonContent.Create(category));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task DeleteCategory(int categoryId)
    {
        var response = await _client.DeleteAsync($"/v1/products/{categoryId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}