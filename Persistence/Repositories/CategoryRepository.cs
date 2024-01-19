using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly IGenericRepository<SubCategory> _repository;

        public CategoryRepository(IGenericRepository<SubCategory> repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetAllCategoriesDto>> GetAllCategories()
        {
            return await _repository.Entities.Include(q=>q.Category).Where(a=>a.Category.IsDeleted == false)
               .GroupBy(e => e.Category.Id)
               .Select(group => new GetAllCategoriesDto
               {
                   Id = group.Key,
                   CategoryName = group.Select(a => a.Category.Name).SingleOrDefault(),
                   SubCategories = group.Select(c => new SubCategoryInfoDto
                   {
                       Id= c.Id,
                       Title = c.Title
                   }).ToList()
               })
               .ToListAsync();
        }
    }
}
