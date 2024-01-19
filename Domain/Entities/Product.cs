using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product:BaseEntity
    {

        [Required, StringLength(50), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(50), Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
       
        public string ImageUrl { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
    }
}
