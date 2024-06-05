using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Services;

namespace Veterinary.Controllers.Owners
{
    public class OwnersController : ControllerBase
    {
        //Dependency inyection
        private readonly IOwnersRepository _ownersRepository;

        //constructor 
        public OwnersController(IOwnersRepository ownersRepository){

            _ownersRepository = ownersRepository;
        }

        [HttpGet]
        [Route("api/owners")]
        public async Task<IActionResult> GetOwnersAsync(){

            try{
                var result = await _ownersRepository.GetAll();
            
                return Ok(result);

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/owners/{id}")]
        public async Task<IActionResult> GetById(int id){
            try{
                var result = await _ownersRepository.GetById(id);
                if(result == null) return BadRequest("Owner not found");

                return Ok(result);

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}