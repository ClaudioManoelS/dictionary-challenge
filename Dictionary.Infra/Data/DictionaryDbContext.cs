using Dictionary.Domain.DictionaryContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Infra.Data;

public class DictionaryDbContext : DbContext
{
  public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options) : base(options)
  { }

  public DbSet<User>? Users { get; set; }
  public DbSet<Entry>? Entries { get; set; }
  public DbSet<History>? Histories { get; set; }
  public DbSet<Favorite>? Favorites { get; set; }

}