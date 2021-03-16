using JingetSample.Domain.Entities;
using JingetSample.Infrastructure.Data.EF.MappingConfigurations;
using Microsoft.EntityFrameworkCore;

namespace JingetSample.Infrastructure.Data.EF
{
    public class JingetSampleContext : DbContext
    {
        public JingetSampleContext(DbContextOptions<JingetSampleContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMappingConfiguration());
        }
    }
}
