using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("siparisdetay")]
    [ApiController]
    public class SiparisDetayContoller : ControllerBase
    {
        private readonly ISiparisDetayRepository _siparisDetayRepo;
        public SiparisDetayContoller(ISiparisDetayRepository siparisDetayRepo)
        {
            _siparisDetayRepo = siparisDetayRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSiparisDetay()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var siparisDetaylari = await _siparisDetayRepo.GetSiparisDetaylarAsync();
           
            return Ok(siparisDetaylari);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiparisDetayBySiparisId([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var siparisDetay = await _siparisDetayRepo.GetSiparisDetayBySiparisIdAsync(id);
           
            if(siparisDetay == null)
                return NotFound("Böyle bir siparis yok");
            
            return Ok(siparisDetay);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSiparisDetaylarByUserId([FromRoute] string userId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var siparisDetaylari = await _siparisDetayRepo.GetSiparisDetaylarByUserIdAsync(userId);

            return Ok(siparisDetaylari);
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateSiparisDetay([FromBody] SiparisDetayCreateDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var siparisDetay = await _siparisDetayRepo.CreateSiparisDetayAsync(dto);

            return CreatedAtAction("Siparis detayi olusturuldu", siparisDetay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiparisDetay([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var siparisDetay = await _siparisDetayRepo.DeleteSiparisDetayByIdAsync(id);

            if(siparisDetay == null)
                return BadRequest("Böyle bir siparis yok");
            
            return Ok(siparisDetay);
        }
    }
}