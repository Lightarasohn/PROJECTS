using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Portfolio;
using api.Models;

namespace api.Mappers
{
    public static class PortfolioMappers
    {
        public static PortfolioDto ToPortfolioDto(this CreatedPortfolioDto dto)
        {
            return new PortfolioDto
            {
                StockId = dto.StockId,
                Stock = dto.Stock,
                Username = dto.Username
            };
        }

        public static PortfolioDto ToPortfolioDto(this DeletedPortfolioDto dto)
        {
            return new PortfolioDto
            {
                StockId = dto.StockId,
                Stock = dto.Stock,
                Username = dto.Username
            };
        }
    }
}