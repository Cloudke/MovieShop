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
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Review>> GetAllReviewsByUser(int id)
        {
            var reviews = await _dbContext.Review.Where(r => r.UserId == id).Include(r=>r.User).Include(r=>r.Movie).ToListAsync();
            return reviews;
        }
    }
}
