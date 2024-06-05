using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Veterinary.Models
{
    public class Owner
    {
        public int Id { get; set; }
        //public int QuoteId { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Pet>? Pets { get; set; }
    }
}