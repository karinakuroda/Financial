using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3_Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NIF { get; set; }

        public virtual List<Transaction> Transactions { get; private set; }

        public virtual List<Goal> Goals { get; set; }
    }
}
