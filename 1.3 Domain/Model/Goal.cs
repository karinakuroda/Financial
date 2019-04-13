using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3_Domain.Model
{
    public class Goal
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int TagCategoryId { get; set; }

        public TagCategory TagCategory { get; set; }

        public decimal Amount { get; set; }
        
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
