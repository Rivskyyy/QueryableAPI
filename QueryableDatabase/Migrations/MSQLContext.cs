using Microsoft.EntityFrameworkCore;
using QueryableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableDatabase.Migrations
{
    public class MSQLContext : DbContext
    {
        public MSQLContext(DbContextOptions<MSQLContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Building> Buildings { get; set; }
/*
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }*/
    }
}
