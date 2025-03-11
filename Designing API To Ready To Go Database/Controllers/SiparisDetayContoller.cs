using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var siparisDetaylari = await _siparisDetayRepo.GetSiparisDetaylarAsync();
           
            return Ok(siparisDetaylari);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiparisDetayBySiparisId([FromRoute] int id)
        {
            var siparisDetay = await _siparisDetayRepo.GetSiparisDetayBySiparisIdAsync(id);
           
            if(siparisDetay == null)
                return NotFound("Böyle bir siparis yok");
            
            return Ok(siparisDetay);
        }
    }
}