using EndPoint.Minimal.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Minimal.Api.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Genre> Genres { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().Property(c => c.Name).HasMaxLength(200).IsRequired();

    }
}