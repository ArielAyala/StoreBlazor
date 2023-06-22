namespace StoreBlazor;

public interface IProductService
{
    Task<List<Product>?> GetProducts();
    Task AddProduct(Product product);
    Task DeleteProduct(int idProduct);
}