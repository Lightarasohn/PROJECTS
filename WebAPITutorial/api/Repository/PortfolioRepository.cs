using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Portfolio;
using api.DTOs.Stock;
using api.Interfaces;
using api.Mappers;
using api.Migrations;
using api.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(UserManager<AppUser> userManager, IStockRepository stockRepository,
        ApplicationDBContext context)
        {
            _userManager = userManager;
            _stockRepo = stockRepository;
            _context = context;
        }

        public async Task<CreatedPortfolioDto> CreatePortfolioAsync(string username, string stockSymbol)
        {
            var user = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(stockSymbol);
            Console.WriteLine(stock);
            if(stock == null) return new CreatedPortfolioDto { IsStockFound = false };

            var IsStockExistInPortfolio = await GetUserPortfoliosByNameAsync(user!.UserName!);
            if(IsStockExistInPortfolio.FirstOrDefault(s => s.Id == stock.Id) != null)
            {
                return new CreatedPortfolioDto { IsStockExist = true, IsStockFound = true };
            }

            var portfolio = new Models.Portfolio
            {
                StockId = stock.Id,
                Stock = stock,
                AppUser = user,
                AppUserId = user.Id
            };

            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();

            return new CreatedPortfolioDto
            {
                StockId = stock.Id,
                Stock = stock.ToStockDto(),
                IsStockExist = false,
                IsStockFound = true,
                Username = user.NormalizedUserName
            };
        }

        public async Task<DeletedPortfolioDto> DeletePortfolioAsync(string username, string stockSymbol)
        {
            
            var stock = await _stockRepo.GetBySymbolAsync(stockSymbol);
            if(stock == null) return new DeletedPortfolioDto { IsStockFound = false };
            var portfolio = await _context.Portfolios.FirstOrDefaultAsync(p =>
                            p.AppUser.NormalizedUserName == username && p.StockId == stock.Id);
            if(portfolio == null) return new DeletedPortfolioDto { IsPortfolioFound = false, IsStockFound = true };

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();

            return new DeletedPortfolioDto
            {
                IsPortfolioFound = true,
                IsStockFound = true,
                StockId = portfolio.StockId,
                Stock = portfolio.Stock.ToStockDto(),
                Username = username
            };
        }

        public async Task<List<StockDto>> GetUserPortfoliosByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userPortfolios = await _context.Portfolios.Where(p => p.AppUserId == user!.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Industry = stock.Stock.Industry,
                Symbol = stock.Stock.Symbol,
                LastDiv = stock.Stock.LastDiv,
                MarketCap = stock.Stock.MarketCap,
                comments = stock.Stock.comments,
                CompanyName = stock.Stock.CompanyName
            }).Select(s => s.ToStockDto()).ToListAsync();

            return userPortfolios;
        }

    }
}