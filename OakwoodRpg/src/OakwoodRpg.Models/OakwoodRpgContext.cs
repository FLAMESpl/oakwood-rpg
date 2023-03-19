using Microsoft.EntityFrameworkCore;

namespace OakwoodRpg.Models;

internal class OakwoodRpgContext : DbContext
{
    public OakwoodRpgContext(DbContextOptions<OakwoodRpgContext> dbContextOptions) : base(dbContextOptions) { }
}
