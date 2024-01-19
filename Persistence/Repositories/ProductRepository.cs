using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductRepository(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProductDeatailsDto>> GetProductList()
        {
            return await _repository.Entities.Include(q => q.SubCategory).Select(c => new ProductDeatailsDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Price = c.Price,
                CategoryName = c.SubCategory.Title
            }).ToListAsync();
        }
    }
}
