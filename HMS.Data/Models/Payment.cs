using System;
using System.Collections.Generic;

#nullable disable

namespace HMS.Data.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
