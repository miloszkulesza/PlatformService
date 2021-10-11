using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using System.Diagnostics.CodeAnalysis;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
