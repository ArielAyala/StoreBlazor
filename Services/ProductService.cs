using System.Text.Json;


namespace StoreBlazor;

public class ProductService: IProductService
{
    public readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public ProductService(HttpClient httpClient, JsonSerializerOptions options)
    {
        _client = httpClient;
        _options = options;
    }

    public async Task<List<Product>?> GetProducts()
    {
        var response = await _client.GetAsync("/v1/products");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<List<Product>>(content, _options);
    }
}