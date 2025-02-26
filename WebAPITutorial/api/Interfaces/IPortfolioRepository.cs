using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Portfolio;
using api.DTOs.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<List<StockDto>> GetUserPortfoliosByNameAsync(string username);
        public Task<CreatedPortfolioDto> CreatePortfolioAsync(string username, string stockSymbol);
        public Task<DeletedPortfolioDto> DeletePortfolioAsync(string username, string stockSymbol);
    }
}