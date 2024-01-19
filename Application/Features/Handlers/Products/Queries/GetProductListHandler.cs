using Application.DTOs;
using Application.Features.Requests.Products.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Shared;

namespace Application.Features.Handlers.Products.Queries
{
    public class GetProductListHandler : IRequestHandler<GetProductListRequest, Result<IList<ProductDeatailsDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<IList<ProductDeatailsDto>>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _productRepository.GetProductList();
                var new_list = _mapper.Map<IList<ProductDeatailsDto>>(list);
                return await Result<IList<ProductDeatailsDto>>.SuccessAsync(new_list);
            }
            catch (Exception)
            {
                return await Result<IList<ProductDeatailsDto>>.FailureAsync("error!");
            }
        }
    }
}
