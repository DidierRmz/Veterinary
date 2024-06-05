using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;
using Veterinary.Models;

namespace Veterinary.Controllers.Quotes
{
    public class QuoteUpdateController : ControllerBase
    {
        //Dependency inyection
        private readonly IQuotesRepository _quotesRepository;

        //constructor 
        public QuoteUpdateController(IQuotesRepository quotesRepository)
        {

            _quotesRepository = quotesRepository;
        }
        [HttpPut]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] Quote quote)
        {

            if (!ModelState.IsValid)
                return BadRequest("Incomplete data quote");

            try
            {

                var resultQuote = await _quotesRepository.GetById(id);
                if (resultQuote == null)
                    return NotFound($"Not found quote {id}");


                var result = await _quotesRepository.Update(quote);
                if (result == null) return BadRequest("aaaa");

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