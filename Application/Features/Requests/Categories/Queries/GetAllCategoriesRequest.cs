using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Features.Requests.Categories.Queries
{
    public class GetAllCategoriesRequest:IRequest<Result<IList<GetAllCategoriesDto>>>
    {
    }
}
