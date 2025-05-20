namespace Infrastructure.Data.DB; 

using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// This class is used to configure the database context for the application.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// This property is used to get the products from the database.
    /// </summary>
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    /// <summary>
    /// This property is used to get the categories from the database.
    /// </summary>
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    /// <summary>
    /// Gets or sets the database connection string.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    /// <summary>
    /// This method is used to configure the model for the database context.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category1)
            .WithMany()
            .HasForeignKey(p => p.Category1Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category2)
            .WithMany()
            .HasForeignKey(p => p.Category2Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category3)
            .WithMany()
            .HasForeignKey(p => p.Category3Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category1)
            .AutoInclude();

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category2)
            .AutoInclude();

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category3)
            .AutoInclude();
    }
}
