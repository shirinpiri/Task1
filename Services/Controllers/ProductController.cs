using Application.DTOs;
using Application.Features.Requests.Products;
using Application.Features.Requests.Products.Commands;
using Application.Features.Requests.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("GetProductList")]
        public async Task<ActionResult<Result<IList<ProductDeatailsDto>>>> GetProductList()
        {
            try
            {
                if (!ModelState.IsValid)
                    return await Result<IList<ProductDeatailsDto>>.FailureAsync("Invalid payload");
                return await _mediator.Send(new GetProductListRequest());
            }
            catch (Exception ex)
            {
                return await Result<IList<ProductDeatailsDto>>.FailureAsync("network error!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> Create([FromForm] CreateProductDto command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return await Result<Guid>.FailureAsync("Invalid payload");
                return await _mediator.Send(new CreateProductRequest(command));
            }
            catch (Exception ex)
            {
                return await Result<Guid>.FailureAsync("network error!");
            }
        }
    }
}
