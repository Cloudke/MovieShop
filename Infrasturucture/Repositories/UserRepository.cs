using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetTop30Users()
        {
            var users = await _dbContext.User.OrderByDescending(m => m.Id).Take(30).ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
