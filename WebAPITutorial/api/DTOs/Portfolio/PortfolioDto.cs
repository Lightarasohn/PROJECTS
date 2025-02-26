using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;

namespace api.DTOs.Portfolio
{
    public class PortfolioDto
    {
        public string? Username { get; set; }
        public int StockId { get; set; }
        public StockDto? Stock { get; set; }
    }
}