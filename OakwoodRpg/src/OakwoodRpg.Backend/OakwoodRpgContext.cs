using Microsoft.EntityFrameworkCore;

namespace OakwoodRpg.Backend;

internal class OakwoodRpgContext : DbContext
{
    public OakwoodRpgContext(DbContextOptions<OakwoodRpgContext> dbContextOptions) : base(dbContextOptions) { }
}
