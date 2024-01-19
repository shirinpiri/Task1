using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Features.Requests.Products.Queries
{
    public class GetProductListRequest : IRequest<Result<IList<ProductDeatailsDto>>>
    {
    }
}
