using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountRepository(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<CreatedUserDto> CreateUserAsync(RegisterDto registerDto)
        {

            try
            {//Parola appUser nesnesine atanmaz çünkü _userManager.CreateAsync(Model, Password) şeklinde çalışabiliyor
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Username
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        return new CreatedUserDto
                        {
                            Errors = null,
                            Exception = null,
                            IsSucceed = true,
                            UserDto = new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        };
                    }
                    else
                    {
                        return new CreatedUserDto
                        {
                            IsSucceed = false,
                            Errors = roleResult.Errors
                        };
                    }
                }
                else
                {
                    return new CreatedUserDto
                    {
                        IsSucceed = false,
                        Errors = createdUser.Errors
                    };
                }
            }
            catch (Exception e)
            {
                return new CreatedUserDto
                {
                    IsSucceed = false,
                    Exception = e
                };
            }
        }

        public async Task<AppUser?> FindUserByUsernameTokenAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<LoggedInUserDto> LoginUserAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username!.ToLower());
                
                if (user == null)
                    return new LoggedInUserDto { IsSucceed = false };

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);

                if (!result.Succeeded)
                    return new LoggedInUserDto
                    {
                        IsUsernameSucceed = true,
                        IsPasswordSucceed = false,
                        IsSucceed = false
                    };

                return new LoggedInUserDto
                {
                    IsUsernameSucceed = true,
                    IsPasswordSucceed = true,
                    IsSucceed = true,
                    UserDto = new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                };
            }
            catch (Exception e)
            {
                return new LoggedInUserDto{ IsSucceed = false, Exception = e };
            }
        }
    }
}