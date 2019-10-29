using MCB.Security.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Configuration
{
    public class AdminUserConfiguration : IEntityTypeConfiguration<AdminUserEntity>
    {
        public void Configure(EntityTypeBuilder<AdminUserEntity> builder)
        {
            builder.HasKey(e => e.UserGuid);
            builder.Property(e => e.UserGuid).UseIdentityColumn();
            builder.Ignore(e => e.RefreshTokens);
            builder.ToTable("TBLadmin_user");
        }
    }
}
