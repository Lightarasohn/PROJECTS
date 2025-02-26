using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        public Task<CreatedUserDto> CreateUserAsync(RegisterDto registerDto);
        public Task<LoggedInUserDto> LoginUserAsync(LoginDto loginDto);
        public Task<AppUser?> FindUserByUsernameTokenAsync(string username);
    }
}