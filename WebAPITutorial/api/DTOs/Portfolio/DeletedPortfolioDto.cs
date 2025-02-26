using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;

namespace api.DTOs.Portfolio
{
    public class DeletedPortfolioDto
    {
        public string? Username { get; set; }
        public int StockId { get; set; }
        public StockDto? Stock { get; set; }
        public bool IsStockFound { get; set; } = false;
        public bool IsPortfolioFound { get; set; }
    }
}