using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SubCategory:BaseEntity
    {
        public SubCategory()
        {
            ProductList = new List<Product>();
        }
        public string Title { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public IList<Product> ProductList { get; set; }
    }
}
