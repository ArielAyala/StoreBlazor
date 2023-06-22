namespace StoreBlazor;

public interface IProductService
{
    Task<List<Product>?> GetProducts();
}