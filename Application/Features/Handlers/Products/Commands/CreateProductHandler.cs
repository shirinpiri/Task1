using Application.Features.Requests.Products.Commands;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using MediatR;
using Shared;

namespace Application.Features.Handlers.Products.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CreateProductHandler(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Result<Guid>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            string ImagePath = "/Uploads/Images/";
            try
            {
                Guid new_id = Guid.NewGuid();

                Product p = new Product();
                p.Id = new_id;
                p.Title = request.CreateProductDto.Title;
                p.Description = request.CreateProductDto.Description;
                p.Price = request.CreateProductDto.Price;
                p.ImageUrl = request.CreateProductDto.ImageUrl != null ? ImagePath + new_id.ToString() + Path.GetExtension(request.CreateProductDto.ImageUrl.FileName) : null;
                p.SubCategoryId = request.CreateProductDto.SubCategoryId;

                await _unitOfWork.Repository<Product>().AddAsync(p);

                //upload image
                bool imageUploaded = false;
                if (request.CreateProductDto.ImageUrl != null)
                {
                    Task<string> uploadFlag = _fileService.UploadFile(request.CreateProductDto.ImageUrl, new_id.ToString(), ImagePath);
                    if (uploadFlag.Result.Equals("success"))
                        imageUploaded = true;
                }
                else
                    imageUploaded = true;

                if (imageUploaded)
                {
                    await _unitOfWork.Save(cancellationToken);
                }
                return await Result<Guid>.SuccessAsync(p.Id, "Product Created.");

            }
            catch (Exception)
            {
                return await Result<Guid>.FailureAsync("error!");
            }
        }
    }
}
