using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account
{
    public class LoggedInUserDto
    {
        public bool IsUsernameSucceed { get; set; } = false;
        public bool IsPasswordSucceed { get; set; } = false;
        public bool IsSucceed { get; set; } = false;
        public Exception? Exception { get; set; } = null;
        public NewUserDto? UserDto { get; set; }
    }
}