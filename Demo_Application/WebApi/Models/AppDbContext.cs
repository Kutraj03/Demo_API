using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<URL_tbl> URL_tbl { get; set; }
    }
}
