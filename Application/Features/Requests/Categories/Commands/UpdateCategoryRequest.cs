using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Features.Requests.Categories.Commands
{
    public class UpdateCategoryRequest:IRequest<Result<bool>>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }

        public UpdateCategoryRequest(UpdateCategoryDto updateCategoryDto)
        {
            UpdateCategoryDto = updateCategoryDto;
        }
    }
}
