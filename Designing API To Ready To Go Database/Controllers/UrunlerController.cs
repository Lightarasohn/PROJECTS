using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
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
        public async Task<IActionResult> GetAllUrunler()
        {
            var urunler = await _urunlerRepo.GetAllUrunlerAsync();

            return Ok(urunler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrunById([FromRoute] int id)
        {
            var urun = await _urunlerRepo.GetUrunByIdAsync(id);

            if(urun == null)
                return BadRequest("Böyle bir urun yok");

            return Ok(urun);
        }
    }
}