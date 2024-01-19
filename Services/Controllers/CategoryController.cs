using Application.DTOs;
using Application.Features.Requests.Categories.Commands;
using Application.Features.Requests.Categories.Queries;
using Application.Features.Requests.Products.Commands;
using Application.Features.Requests.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("GetCategoryList")]
        public async Task<ActionResult<Result<IList<GetAllCategoriesDto>>>> GetCategoryList()
        {
            try
            {
                if (!ModelState.IsValid)
                    return await Result<IList<GetAllCategoriesDto>>.FailureAsync("Invalid payload");
                return await _mediator.Send(new GetAllCategoriesRequest());
            }
            catch (Exception ex)
            {
                return await Result<IList<GetAllCategoriesDto>>.FailureAsync("network error!");
            }
        }


        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<ActionResult<Result<bool>>> UpdateCategory([FromBody] UpdateCategoryDto command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return await Result<bool>.FailureAsync("Invalid payload");
                return await _mediator.Send(new UpdateCategoryRequest(command));
            }
            catch (Exception ex)
            {
                return await Result<bool>.FailureAsync("network error!");
            }
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public async Task<ActionResult<Result<bool>>> DeleteCategory(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return await Result<bool>.FailureAsync("Invalid payload");
                return await _mediator.Send(new DeleteCategoryRequest(Id));
            }
            catch (Exception ex)
            {
                return await Result<bool>.FailureAsync("network error!");
            }
        }
    }
}
