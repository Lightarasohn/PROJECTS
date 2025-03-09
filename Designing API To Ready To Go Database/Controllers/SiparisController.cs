using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("siparis")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSiparis(){
            return Ok();
        }
    }
}