using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("siparis")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisRepository _siparisRepo;
        public SiparisController(ISiparisRepository siparisRepo)
        {
            _siparisRepo = siparisRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSiparis()
        {
            var siparisler = await _siparisRepo.GetSiparislerAsync();
            
            return Ok(siparisler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiparisById([FromRoute] int id)
        {
            var siparis = await _siparisRepo.GetSiparisByIdAsync(id);
            
            if(siparis == null)
                return NotFound("Böyle bir sipariş yok");
            
            return Ok(siparis);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSiparisByUserId([FromRoute] string userId)
        {
            var siparisler = await _siparisRepo.GetSiparislerByUserIdAsync(userId);
            
            return Ok(siparisler);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSiparis([FromBody] SiparisCreateDto dto)
        {
            var siparis = await _siparisRepo.CreateSiparisAsync(dto);

            return CreatedAtAction("Siparis olusturuldu", dto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSiparis([FromBody] Siparisler siparis)
        {
            var silinenSiparis = await _siparisRepo.DeleteSiparis(siparis);

            if(siparis == null)
                return BadRequest("Böyle bir sipariş yok");

            return Ok(silinenSiparis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiparisById([FromRoute] int id)
        {
            var silinenSiparis = await _siparisRepo.DeleteSiparisByIdAsync(id);

            if(silinenSiparis == null)
                return BadRequest("Böyle bir sipariş yok");

            return Ok(silinenSiparis);
        }
    }
}