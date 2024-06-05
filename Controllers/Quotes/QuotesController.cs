using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;

namespace Veterinary.Controllers.Quotes
{
    public class QuotesController : ControllerBase
    {
        //Dependency inyection
        private readonly IQuotesRepository _quotesRepository;

        //constructor 
        public QuotesController(IQuotesRepository quotesRepository)
        {

            _quotesRepository = quotesRepository;
        }
        [HttpGet]
        [Route("api/quotes")]
        public async Task<IActionResult> GetQuotesAsync()
        {

            try
            {
                var result = await _quotesRepository.GetAll();

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _quotesRepository.GetById(id);
                if (result == null) return BadRequest("Quote not found");

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}