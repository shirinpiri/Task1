using MediatR;
using Shared;

namespace Application.Features.Requests.Categories.Commands
{
    public class DeleteCategoryRequest:IRequest<Result<bool>>
    {
        public Guid Id { get; set; }

        public DeleteCategoryRequest(Guid id)
        {
            Id = id;
        }
    }
}
