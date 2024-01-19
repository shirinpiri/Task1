using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Features.Requests.Products.Commands
{
    public class CreateProductRequest : IRequest<Result<Guid>>
    {
        public CreateProductDto CreateProductDto { get; set; }

        public CreateProductRequest(CreateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }
    }
}
