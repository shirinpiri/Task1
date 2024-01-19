using Domain.Common;

namespace Domain.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            SubCategory = new List<SubCategory>();
        }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public IList<SubCategory> SubCategory { get; set; }
    }
}
