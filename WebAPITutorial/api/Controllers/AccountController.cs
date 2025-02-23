using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Kulanıcı eklemeyi kolaylaştıran ve AccountRepo yazmamıza gerek bırakmayan "Microsoft.AspNetCore.Identity.UserManager" bir manager
        private readonly IAccountRepository _accountRepo;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        [HttpPost("/api/Account/Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            if (!ModelState.IsValid) return BadRequest("Username and Password is required");

            var loginResult = await _accountRepo.LoginUserAsync(loginDto);

            if(loginResult.Exception != null)
                return StatusCode(500, loginResult.Exception);
            
            if(!loginResult.IsUsernameSucceed)
                return StatusCode(500, "Invalid Username");

            if(!loginResult.IsPasswordSucceed)
                return StatusCode(500, "Invalid Password or Username");

            return Ok(loginResult.UserDto);
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _accountRepo.CreateUserAsync(registerDto);

            if(createdUser.Errors != null) return StatusCode(500, createdUser.Errors);
            if(createdUser.Exception != null) return StatusCode(500, createdUser.Exception);



            return Ok(createdUser.UserDto);

        }
    }
}