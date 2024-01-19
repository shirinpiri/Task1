using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<ProductDeatailsDto>> GetProductList();
    }
}
