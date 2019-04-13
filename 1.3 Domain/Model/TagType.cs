using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3_Domain.Model
{
    public class TagCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public OperationType OperationType { get; set; }
    }
}
