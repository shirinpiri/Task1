using Application.Features.Requests.Categories.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Categories.Commands
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);
                category.IsDeleted = true;
                await _unitOfWork.Repository<Category>().UpdateAsync(category);
                await _unitOfWork.Save(cancellationToken);
                return await Result<bool>.SuccessAsync(true, "Category Deleted.");

            }
            catch (Exception)
            {
                return await Result<bool>.FailureAsync("error!");
            }
        }
    }
}
