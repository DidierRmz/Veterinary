using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Models;

namespace Veterinary.Services
{
    public interface IVetsRepository
    {
        Task <IEnumerable<Vet>> GetAll();
        Task<Vet> GetById(int id);
    }
}