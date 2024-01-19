namespace Application.DTOs
{
    public class GetAllCategoriesDto
    {
        public GetAllCategoriesDto()
        {
            SubCategories = new List<SubCategoryInfoDto>();
        }
        public Guid Id { get; set; }
        public string  CategoryName { get; set; }
        public IList<SubCategoryInfoDto> SubCategories { get; set; }
    }
}
