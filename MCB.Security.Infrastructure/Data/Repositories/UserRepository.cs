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
        Task<SiteUserEntity> GetUserAsync(int guid);
        Task<SiteUserEntity> GetUserAsync(string userName, string password);
        Task<int> UpdateUser(SiteUserEntity user);
    }

    public class UserRepository : IUserRepository
    {
        public async Task<SiteUserEntity> GetUserAsync(int guid)
        {
            using (MasterpieceContext context = new MasterpieceContext())
            {
                return await context.SiteUsers.Where(e => e.SiteUserGuid == guid).SingleOrDefaultAsync();
            }
        }

        public async Task<SiteUserEntity> GetUserAsync(string userName, string password)
        {
            using (MasterpieceContext context = new MasterpieceContext())
            {
                return await context.SiteUsers.Where(e => e.SiteUserName == userName).SingleOrDefaultAsync();
            }
        }

        public async Task<int> UpdateUser(SiteUserEntity user)
        {
            return 1;
        }
    }
}
