using System.Collections.Generic;

namespace _1._3_Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }

        public int TagCategoryId { get; set; }

        public TagCategory TagCategory { get; set; }
        
        public string Regex { get; set; }
    }
}
