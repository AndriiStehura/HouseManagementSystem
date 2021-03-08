using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace HMS.Data.Models
{
    public partial class Service
    {
        public Service()
        {
            Expenses = new HashSet<Expense>();
        }

        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Measurement { get; set; }
        public int? ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
