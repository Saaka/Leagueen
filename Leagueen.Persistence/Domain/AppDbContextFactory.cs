﻿using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override string MigrationsTable => PersistenceConstants.DefaultMigrationsTable;

        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
