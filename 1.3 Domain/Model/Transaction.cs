using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3_Domain.Model
{
    public class Transaction
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }


    }
}
