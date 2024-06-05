using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;
using Veterinary.Models;

namespace Veterinary.Controllers.Pets
{
    public class PetsCreateController : ControllerBase
    {
        //Dependency inyection
        private readonly IPetsRepository _petsRepository;

        //constructor 
        public PetsCreateController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }

        [HttpPost]
        [Route("api/pets/create")]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet)
        {

            if (!ModelState.IsValid)
                return BadRequest("Incomplete data pet");

            try
            {
                var result = await _petsRepository.Create(pet);
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