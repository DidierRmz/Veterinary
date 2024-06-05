using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Veterinary.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public int VetId { get; set; }
        public string? Description { get; set; }
        public Pet? pet { get; set; }
        public Vet? vet { get; set; }

/*         [JsonIgnore]
        public List<Owner>? owners { get; set; } */
    }
}