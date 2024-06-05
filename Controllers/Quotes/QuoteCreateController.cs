using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;
using Veterinary.Models;

namespace Veterinary.Controllers.Quotes
{
    public class QuoteCreateController : ControllerBase
    {
        //Dependency inyection
        private readonly IQuotesRepository _quotesRepository;

        //constructor 
        public QuoteCreateController(IQuotesRepository quotesRepository)
        {

            _quotesRepository = quotesRepository;
        }
        [HttpPost]
        [Route("api/quotes/create")]
        public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
        {

            if (!ModelState.IsValid)
                return BadRequest("Incomplete data quote");

            try
            {
                var result = await _quotesRepository.Create(quote);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}