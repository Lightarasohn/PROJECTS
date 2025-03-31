using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("urun")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly IUrunlerRepository _urunlerRepo;
        public UrunlerController(IUrunlerRepository urunlerRepo)
        {
            _urunlerRepo = urunlerRepo;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUrunler()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var urunler = await _urunlerRepo.GetAllUrunlerAsync();

            return Ok(urunler);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUrunById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var urun = await _urunlerRepo.GetUrunByIdAsync(id);

            if(urun == null)
                return BadRequest("Böyle bir urun yok");

            return Ok(urun);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUrun(UrunlerCreateDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUrun = await _urunlerRepo.CreateUrunAsync(dto);

            return CreatedAtAction(nameof(GetUrunById), new {createdUrun.Id} ,createdUrun);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUrun([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var deletedUrun = await _urunlerRepo.DeleteUrunAsync(id);

            if(deletedUrun == null)
                return BadRequest("Ürün silinemedi. Böyle bir ürün yok");
            
            return Ok(deletedUrun);
        }
    }
}