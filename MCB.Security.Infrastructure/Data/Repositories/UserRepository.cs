using MCB.Security.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Security.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserAsync(int guid);
        Task<UserEntity> GetUserAsync(string userName, string password);
    }

    public class UserRepository
    {

    }
}
