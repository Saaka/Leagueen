﻿using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Identity
{
    public class AppIdentityDbContext
        : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppIdentityDbContext()
        {
        }
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(PersistenceConfig.DefaultSchema);
            builder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDbContext).Assembly);
        }
    }
}
