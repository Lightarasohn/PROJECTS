using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IPasswordService _passwordService;
        private readonly MarketContext _context;
        private readonly ITokenService _tokenService;
        public AccountRepository(MarketContext context, ITokenService tokenService, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public async Task<MusteriTokenDto?> LoginAsync(MusteriLoginDto dto)
        {
            var musteri = await _context.Musteriler.FirstOrDefaultAsync(mus => mus.KullaniciAdi == dto.KullaniciAdi);
            if(musteri == null)
                return null;
            var password = _passwordService.VerificatePassword(musteri, musteri.ParolaH!, dto.Parola!);

            if(password == PasswordVerificationResult.Failed)
                return null;

            var musteriToken = _tokenService.CreateToken(musteri);

            return musteri.ToTokenDto(musteriToken);
        }
    }
}