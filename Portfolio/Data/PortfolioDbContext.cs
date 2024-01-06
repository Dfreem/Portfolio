using Microsoft.EntityFrameworkCore;

using Portfolio.Models;

namespace Portfolio.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext()
    {
        
    }
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
        
    }

    public DbSet<ContactMessage> ContactMessages { get; set; }

}
