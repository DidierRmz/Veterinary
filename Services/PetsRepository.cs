using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Models;

namespace Veterinary.Services
{
    public class PetsRepository : IPetsRepository
    {
        public readonly DataContext _context;
        public PetsRepository(DataContext context)
        {

            _context = context;

        }

        public async  Task<Pet> Create(Pet pet)
        {
            var result  = await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Pet>> GetAll()
        {
            return await _context.Pets.Include(c => c.owner).ToListAsync();
        }
        public async Task<Pet> GetById(int id)
        {
            return await _context.Pets.Include(c => c.owner).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Pet> Update(Pet pet)
        {
            var result = await _context.Pets.FirstOrDefaultAsync(c =>c.Id ==pet.Id);
            
            if(result != null){
            result.Name = pet.Name;
            result.Specie = pet.Specie;
            result.Race = pet.Race;
            result.DateBirth = pet.DateBirth;
            result.photo = pet.photo;
            result.OwnerId = pet.OwnerId;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}