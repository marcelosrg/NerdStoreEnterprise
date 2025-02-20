using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;

namespace NSE.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProdutoRepository(CatalogContext context)
        {
            _context = context;
        }


        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }
        public void AddProduct(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

      
    }
}
