using Microsoft.EntityFrameworkCore;
using Zwrotne.Domain;

namespace Zwrotne.Infrastructure;

public class ZwrotneDbContext : DbContext
{
    public ZwrotneDbContext(DbContextOptions<ZwrotneDbContext> options) : base(options) 
    {
        
    }

    public DbSet<FeatureRequest> FeatureRequests { get; set; }

}
