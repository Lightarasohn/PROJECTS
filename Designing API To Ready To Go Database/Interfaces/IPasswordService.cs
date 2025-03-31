using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface IPasswordService
    {
        public string HashPassword(Musteriler musteri ,string password);
        public PasswordVerificationResult VerificatePassword(Musteriler musteri, string hashedPassword, string passwordInput);
    }
}