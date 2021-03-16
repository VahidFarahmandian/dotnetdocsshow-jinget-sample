using System;
using Jinget.Infrastructure.Data.EF.MappingConfigurations;
using JingetSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JingetSample.Infrastructure.Data.EF.MappingConfigurations
{
    public class UserMappingConfiguration : BaseMappingConfiguration<UserModel, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserModel> builder)
        {
            base.Configure(builder);

            builder.ToTable("tblUsers", "Account");
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
        }
    }
}
