using NSE.Core.Data;

namespace NSE.Catalogo.API.Models
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(Guid id);

        void AddProduct(Product product);
        void UpdateProduct(Product product);

    }
}
