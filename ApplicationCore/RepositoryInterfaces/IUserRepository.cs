using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository:IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetTop30Users();
        Task<IEnumerable<Favorite>> GetAllFavoriteMovies(int id);
    }
}
