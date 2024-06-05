using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models;
using Veterinary.Services;

namespace Veterinary.Controllers.Owners
{
    public class OwnerCreateController : ControllerBase
    {
        //Dependency inyection
        private readonly IOwnersRepository _ownersRepository;

        //constructor 
        public OwnerCreateController(IOwnersRepository ownersRepository)
        {

            _ownersRepository = ownersRepository;
        }

        [HttpPost]
        [Route("api/owners/create")]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {

            if (!ModelState.IsValid)
                return BadRequest("Incomplete data owner");

            try
            {
                var result = await _ownersRepository.Create(owner);
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