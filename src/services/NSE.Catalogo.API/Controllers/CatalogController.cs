using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebAPI.Core.Identity;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{

    [ApiController]
    [Authorize]
    public class CatalogController : ControllerBase
    {

        public readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("catolo/produtos")]
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetAllProducts();
        }

        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catolo/produtos/{id}")]
        public async Task<Product> GetDetailsProduct(Guid id)
        {
            return await _productRepository.GetProductById(id);
        }

        [AllowAnonymous]
        [HttpPost("catolo/produtos/create")]
        public  void CreateProduct(Product product)
        {
            var createProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Active = product.Active,
                CreatedAt = DateTime.UtcNow,
                Descripition = product.Descripition,
                Image = product.Image,
                StockQuantity = product.StockQuantity


            };

             _productRepository.AddProduct(product);

        }






    }
}
