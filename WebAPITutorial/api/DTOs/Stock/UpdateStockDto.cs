using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class UpdateStockDto
    {
        [Required]
        [MaxLength(5, ErrorMessage = "Symbol must be maximum 5 characters")]
        [MinLength(1, ErrorMessage = "Symbol must have characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(20, ErrorMessage = "CompanyName must be maximum 20 characters")]
        [MinLength(3, ErrorMessage = "CompanyName must be minimum 3 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,1000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Industry must be maximum 20 characters")]
        [MinLength(3, ErrorMessage = "Industry must be minimum 3 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(0,10000000000000000)]
        public long MarketCap { get; set; }
    }
}