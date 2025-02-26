using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepo = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var userPortfolio = await _portfolioRepo.GetUserPortfoliosByNameAsync(username);
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePortfolio([FromBody] string stockSymbol)
        {
            var username = User.GetUsername();
            var createdPortfolio = await _portfolioRepo.CreatePortfolioAsync(username, stockSymbol);
            if(createdPortfolio.IsStockFound == false) return BadRequest("Stock could not found");
            if(createdPortfolio.IsStockExist == true) return BadRequest("Cannot add same stock twice");

            return Ok(createdPortfolio.ToPortfolioDto());
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string stockSymbol)
        {
            var username = User.GetUsername();
            var deletedPortfolio = await _portfolioRepo.DeletePortfolioAsync(username, stockSymbol);
            if(deletedPortfolio.IsStockFound == false) return BadRequest("Stock could not found to delete");

            return Ok(deletedPortfolio.ToPortfolioDto());
        }        
    }
}