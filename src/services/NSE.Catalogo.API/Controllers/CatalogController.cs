using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{

    [ApiController]
    public class CatalogController : ControllerBase
    {

        public readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("catolo/produtos")]
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetAllProducts();
        }

        [HttpGet("catolo/produtos/{id}")]
        public async Task<Product> GetDetailsProduct(Guid id)
        {
            return await _productRepository.GetProductById(id);
        }


     

    }
}
