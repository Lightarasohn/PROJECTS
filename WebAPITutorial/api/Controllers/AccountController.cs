using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Kulanıcı eklemeyi kolaylaştıran ve AccountRepo yazmamıza gerek bırakmayan "Microsoft.AspNetCore.Identity.UserManager" bir manager
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {//Elimizde olmayan ve handle'layamadığımız errorları yakalasın diye try/catch kullanılır
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                //Parola appUser nesnesine atanmaz çünkü _userManager.CreateAsync(Model, Password) şeklinde çalışabiliyor
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Username
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);

                if(createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if(roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.UserName,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }


        }
    }
}