using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Repository
{
    //Repositoryde ise Interfacede yazdığımız methodları gerçek hale getiririz
    //Böylece elimizde controller sınıfları içerisinde kullanacağımız
    //tüm methodları isimleri daha da anlamlandırılmış halleri ile bulundurabiliriz
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock createStock)
        {
            await _context.Stocks.AddAsync(createStock);
            await _context.SaveChangesAsync();

            return createStock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stock == null)
                return null;
            
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UptadeAsync(int id, UpdateStockDto updateStock)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stock == null)
                return null;

            stock.Symbol = updateStock.Symbol;
            stock.CompanyName = updateStock.CompanyName;
            stock.Purchase = updateStock.Purchase;
            stock.LastDiv = updateStock.LastDiv;
            stock.Industry = updateStock.Industry;
            stock.MarketCap = updateStock.MarketCap;

            await _context.SaveChangesAsync();

            return stock;
        }
    }
}