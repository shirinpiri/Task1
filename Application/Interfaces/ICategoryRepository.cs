using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IList<GetAllCategoriesDto>> GetAllCategories();
    }
}
