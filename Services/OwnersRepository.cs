using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Models;

namespace Veterinary.Services
{
    public class OwnersRepository : IOwnersRepository
    {
        public readonly DataContext _context;
        public OwnersRepository(DataContext context)
        {

            _context = context;

        }
        public async  Task<Owner> Create(Owner owner)
        {
            var result  = await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Owner>> GetAll()
        {
            return await _context.Owners.ToListAsync();
        }
        public async Task<Owner> GetById(int id)
        {
            return await _context.Owners.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Owner> Update(Owner owner)
        {
            var result = await _context.Owners.FirstOrDefaultAsync(c =>c.Id ==owner.Id);
            
            if(result != null){
            result.Names = owner.Names;
            result.LastNames = owner.LastNames;
            result.Phone = owner.Phone;
            result.Address = owner.Address;
            result.Email = owner.Email;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}