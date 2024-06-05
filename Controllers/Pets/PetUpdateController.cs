using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;
using Veterinary.Models;

namespace Veterinary.Controllers.Pets
{
    public class PetsUpdateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        //constructor 
        public PetsUpdateController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }
        [HttpPut]
        [Route("api/pets/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet)
        {

            if (!ModelState.IsValid)
                return BadRequest("Incomplete data pet");

            try
            {

                var resultPet = await _petsRepository.GetById(id);
                if (resultPet == null)
                    return NotFound($"Not found pet {id}");


                var result = await _petsRepository.Update(pet);
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