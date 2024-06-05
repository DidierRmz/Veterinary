using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Veterinary.Services;

namespace Veterinary.Controllers.Vets
{
    public class VetsController : ControllerBase
    {
        //Dependency inyection
        private readonly IVetsRepository _vetRepository;

        //constructor 
        public VetsController(IVetsRepository vetsRepository){

            _vetRepository = vetsRepository;
        }

        [HttpGet]
        [Route("api/vets")]
        public async Task<IActionResult> GetVetsAsync(){

            try{
                var result = await _vetRepository.GetAll();
            
                return Ok(result);

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/vets/{id}")]
        public async Task<IActionResult> GetById(int id){
            try{
                var result = await _vetRepository.GetById(id);
                if(result == null) return BadRequest("Vet not found");

                return Ok(result);

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}