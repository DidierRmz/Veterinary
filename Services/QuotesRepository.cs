using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Models;

namespace Veterinary.Services
{
    public class QuotesRepository : IQuotesRepository
    {
        public readonly DataContext _context;
        public QuotesRepository( DataContext context){

            _context = context;

        }

        public async  Task<Quote> Create(Quote quote)
        {
            var result  = await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Quote>> GetAll()
        {
            return await _context.Quotes.Include(c => c.pet).Include(c => c.vet).ToListAsync();
        }
        public async Task<Quote> GetById(int id)
        {
            return await _context.Quotes.Include(c => c.pet).Include(c => c.vet).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Quote> Update(Quote quote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(c =>c.Id ==quote.Id);
            
            if(result != null){
            result.Date = quote.Date;
            result.PetId = quote.PetId;
            result.VetId = quote.VetId;
            result.Description = quote.Description;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}