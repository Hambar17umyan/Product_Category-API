namespace Infrastructure.Data.DB; 

using Application.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

/// <summary>
/// This class is used to create the database context for the application.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// This method is used to create the database context for the application.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(AppConstants.DefaultConnectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
