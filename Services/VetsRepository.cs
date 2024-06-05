using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Models;

namespace Veterinary.Services
{
    public class VetsRepository : IVetsRepository
    {
        public readonly DataContext _context;
        public VetsRepository( DataContext context){

            _context = context;

        }
        public async Task<IEnumerable<Vet>> GetAll()
        {
            return await _context.Vets.Include(c => c.Quotes).ToListAsync();
        }
        public async Task<Vet> GetById(int id)
        {
            return await _context.Vets.Include(c => c.Quotes).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}