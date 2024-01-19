using Domain.Validations;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class CreateProductDto
    {
        [Required, StringLength(50), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(50), Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [NotZero(ErrorMessage = "price can't zero!")]
        public double Price { get; set; }

        public IFormFile ImageUrl { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }
    }
}
