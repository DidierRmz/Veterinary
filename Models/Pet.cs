using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Veterinary.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateTime DateBirth { get; set; }
        public string? photo { get; set; }
        public Owner? owner { get; set; }

        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}