using Devsu.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Identity
{
    public class DevsuIdentityDbContext : IdentityDbContext
    {
        public DevsuIdentityDbContext(DbContextOptions<DevsuIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<RefreshToken>? RefreshTokens { get; set; }
        public virtual DbSet<ApplicationUser>? ApplicationUsers { get; set; }

    }
}
