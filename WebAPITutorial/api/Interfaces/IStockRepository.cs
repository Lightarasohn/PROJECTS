using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    //Interface ile projedeki controller yönetimini sadece URL iş yükü olarak bırakıyoruz
    //Interface içerisine controller sınıfları içinde tekrar tekrar kullanacağımız methodların tanımını yazarız
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync(QueryObject query);
        public Task<Stock?> GetByIdAsync(int id);
        public Task<Stock> CreateAsync(Stock createStock);
        public Task<Stock?> UptadeAsync(int id, UpdateStockDto updateStock);
        public Task<Stock?> DeleteAsync(int id);
        public Task<bool> StockExistAsync(int id);
    }
}