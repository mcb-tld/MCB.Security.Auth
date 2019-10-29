using MCB.Security.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Security.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        Task<AdminUserEntity> GetUserAsync(int guid);
        Task<AdminUserEntity> GetUserAsync(string userName, string password);
        Task<int> UpdateUser(AdminUserEntity user);
    }

    public class UserRepository : IUserRepository
    {
        public async Task<AdminUserEntity> GetUserAsync(int guid)
        {
            using (MasterpieceContext context = new MasterpieceContext())
            {
                return await context.SiteUsers.Where(e => e.UserGuid == guid).SingleOrDefaultAsync();
            }
        }

        public async Task<AdminUserEntity> GetUserAsync(string userName, string password)
        {
            using (MasterpieceContext context = new MasterpieceContext())
            {
                return await context.SiteUsers.Where(e => e.UserName == userName).SingleOrDefaultAsync();
            }
        }

        public async Task<int> UpdateUser(AdminUserEntity user)
        {
            return 1;
        }
    }
}
