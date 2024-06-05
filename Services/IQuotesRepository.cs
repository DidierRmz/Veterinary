using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Models;

namespace Veterinary.Services
{
    public interface IQuotesRepository
    {
        Task <IEnumerable<Quote>> GetAll();
        Task<Quote> GetById(int id);
        Task<Quote> Create(Quote quote);
        Task<Quote> Update(Quote quote);
    }
}