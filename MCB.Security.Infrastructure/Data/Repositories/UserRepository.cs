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
        Task<int> UpdateUser(UserEntity user);
    }

    public class UserRepository : IUserRepository
    {
        public async Task<UserEntity> GetUserAsync(int guid)
        {
            return new UserEntity() { Guid = 123, UserName = "tld" };
        }

        public async Task<UserEntity> GetUserAsync(string userName, string password)
        {
            return new UserEntity() { Guid = 123, UserName = "tld" };
        }

        public async Task<int> UpdateUser(UserEntity user)
        {
            return 1;
        }
    }
}
