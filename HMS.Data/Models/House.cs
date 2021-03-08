using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace HMS.Data.Models
{
    public partial class House
    {
        public House()
        {
            Expenses = new HashSet<Expense>();
            People = new HashSet<Person>();
        }

        public int HouseId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
