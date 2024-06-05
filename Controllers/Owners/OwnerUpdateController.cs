using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models;
using Veterinary.Services;

namespace Simulacro2.Controllers.Owners
{
    
    public class OwnerUpdateController : ControllerBase
    {
        //Dependency inyection
        private readonly IOwnersRepository _ownersRepository;

        //constructor 
        public OwnerUpdateController(IOwnersRepository ownersRepository){

            _ownersRepository = ownersRepository;
        }

        [HttpPut]
        [Route("api/owners/{id}")]
        public async Task<IActionResult> UpdateOwner(int id,[FromBody] Owner owner){

            if(!ModelState.IsValid)
                return BadRequest("Incomplete data owner");

            try{

                var resultOwner = await _ownersRepository.GetById(id);
                if(resultOwner == null) 
                    return NotFound($"Not found owner {id}");


                var result  = await _ownersRepository.Update(owner);
                if(result == null) return BadRequest("aaaa");
                
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