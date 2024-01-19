using Application.DTOs;
using Application.Features.Requests.Categories.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Shared;

namespace Application.Features.Handlers.Categories.Queries
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, Result<IList<GetAllCategoriesDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<IList<GetAllCategoriesDto>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _categoryRepository.GetAllCategories();
                var new_list = _mapper.Map<IList<GetAllCategoriesDto>>(list);
                return await Result<IList<GetAllCategoriesDto>>.SuccessAsync(new_list);
            }
            catch (Exception)
            {
                return await Result<IList<GetAllCategoriesDto>>.FailureAsync("error!");
            }
        }
    }
}
