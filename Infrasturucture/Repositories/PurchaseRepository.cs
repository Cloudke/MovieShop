using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            var purchases = await _dbContext.Purchase.Include(m => m.Movie).OrderByDescending(m=>m.Id)
                .ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesById(int id)
        {
            var purchases = await _dbContext.Purchase.Where(m=>m.UserId == id).Include(m => m.Movie).OrderByDescending(m => m.Id)
                .ToListAsync();
            return purchases;
        }
    }
}
