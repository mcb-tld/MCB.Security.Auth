using MCB.Security.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Configuration
{
    public class SiteUserConfiguration : IEntityTypeConfiguration<SiteUserEntity>
    {
        public void Configure(EntityTypeBuilder<SiteUserEntity> builder)
        {
            builder.HasKey(e => e.SiteUserGuid);
            builder.Property(e => e.SiteUserGuid).UseIdentityColumn();
            builder.Property(e => e.ImportOriginGuid).HasColumnName("import_originGuid");
            builder.Ignore(e => e.RefreshTokens);
            builder.ToTable("TBLsite_user");
        }
    }
}
