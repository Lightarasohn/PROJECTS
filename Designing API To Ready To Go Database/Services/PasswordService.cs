using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Designing_API_To_Ready_To_Go_Database.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<Musteriler> _passwordHasher;
        public PasswordService(IPasswordHasher<Musteriler> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(Musteriler musteri ,string password)
        {
            return _passwordHasher.HashPassword(musteri, password);
        }
    }
}