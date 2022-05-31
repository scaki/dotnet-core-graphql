using Helbiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helbiz.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Id);
    }

    public override int SaveChanges()
    {
        OnBeforeSaving();
        return base.SaveChanges();
    }

    private void OnBeforeSaving()
    {
        var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
        addedEntities.ForEach(e =>
        {
            if (e.Metadata.FindProperty("CreatedAt") != null) e.Property("CreatedAt").CurrentValue = DateTimeOffset.UtcNow;
        });
        var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
        editedEntities.ForEach(e =>
        {
            if (e.Metadata.FindProperty("UpdatedAt") != null) e.Property("UpdatedAt").CurrentValue = DateTimeOffset.UtcNow;
        });
    }
}