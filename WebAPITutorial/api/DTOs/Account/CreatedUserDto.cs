using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.DTOs.Account
{
    public class CreatedUserDto
    {
        public bool IsSucceed { get; set; } = false;
        public NewUserDto? UserDto { get; set; } 
        public IEnumerable<IdentityError>? Errors { get; set; } = null;
        public Exception? Exception { get; set; } = null;
    }
}