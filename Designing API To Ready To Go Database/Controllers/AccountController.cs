using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;
        public AccountController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] MusteriLoginDto dto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var loginMusteri = await _accountRepo.LoginAsync(dto);
            
            if(loginMusteri == null)
                return BadRequest("Musteri Bulunamadi");

            return Ok(loginMusteri);
            
        }
    }
}