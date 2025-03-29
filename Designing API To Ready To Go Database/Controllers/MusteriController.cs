using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("musteri")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly IMusteriRepository _musteriRepo;
        public MusteriController(IMusteriRepository musteriRepo)
        {
            _musteriRepo = musteriRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMusteriler()
        {
            var musteriler = await _musteriRepo.GetAllMusterilerAsync();
            return Ok(musteriler);
        }

        [HttpGet("get/id/{id}")]
        public async Task<IActionResult> GetMusteriById([FromRoute] string id)
        {
            var musteri = await _musteriRepo.GetMusteriByIdAsync(id);

            if(musteri == null)
                return NotFound("Musteri Bulunamadi");

            return Ok(musteri);
        }

        [HttpGet("get/email/{mail}")]
        public async Task<IActionResult> GetMusteriByEmail([FromRoute] string mail)
        {
            var musteri = await _musteriRepo.GetMusteriByEmailAsync(mail);

            if(musteri == null)
                return NotFound("Musteri bulunamdi");
            
            return Ok(musteri);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusteri([FromRoute] string id)
        {
            var musteri = await _musteriRepo.DeleteMusteriByIdAsync(id);

            if(musteri == null)
                return NotFound("Musteri Bulunamadi");

            return Ok(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMusteri([FromBody] MusteriCreateDto dto)
        {
            var createdMusteri = await _musteriRepo.CreateMusteriAsync(dto);

            if(createdMusteri.IsUsernameExist)
                return BadRequest("Kullanici adi kullanimda");

            if(createdMusteri.IsEmailExist)
                return BadRequest("Email kullanimda");

            var musteriTokenDto = createdMusteri.ToMusteriTokenDto();
            
            return CreatedAtAction(nameof(CreateMusteri), new {musteriTokenDto.Id}, musteriTokenDto);
        }
    }
}