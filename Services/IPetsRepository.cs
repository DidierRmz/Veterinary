using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Models;


namespace Veterinary.Services
{
    public interface IPetsRepository
    {
        Task <IEnumerable<Pet>> GetAll();
        Task<Pet> GetById(int id);
        Task<Pet> Create(Pet pet);
        Task<Pet> Update(Pet pet);
    }
}