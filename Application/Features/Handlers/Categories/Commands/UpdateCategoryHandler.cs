using Application.Features.Requests.Categories.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Features.Handlers.Categories.Commands
{
    public class UpdateCategoryHandler:IRequestHandler<UpdateCategoryRequest,Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.UpdateCategoryDto.Id);
                category.Name = request.UpdateCategoryDto.Title;
                await _unitOfWork.Repository<Category>().UpdateAsync(category);
                await _unitOfWork.Save(cancellationToken);
                return await Result<bool>.SuccessAsync(true, "Category Updated.");

            }
            catch (Exception)
            {
                return await Result<bool>.FailureAsync("error!");
            }
        }
    }
}
