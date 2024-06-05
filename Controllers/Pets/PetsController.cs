using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;

namespace Veterinary.Controllers.Pets
{
    public class PetController : ControllerBase
    {
        //Dependency inyection
        private readonly IPetsRepository _petsRepository;

        //constructor 
        public PetController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }
        
        [HttpGet]
        [Route("api/pets")]
        public async Task<IActionResult> GetPetsAsync()
        {

            try
            {
                var result = await _petsRepository.GetAll();

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/pets/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _petsRepository.GetById(id);
                if (result == null) return BadRequest("Pet not found");

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}