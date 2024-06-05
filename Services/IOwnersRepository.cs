using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Models;

namespace Veterinary.Services
{
    public interface IOwnersRepository
    {
        Task <IEnumerable<Owner>> GetAll();
        Task<Owner> GetById(int id);
        Task<Owner> Create(Owner owner);
        Task<Owner> Update(Owner owner);
    }
}