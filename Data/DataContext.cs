using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class DataContext : IdentityDbContext<AppUser>
{
  public DataContext(DbContextOptions options) : base(options)
  {
  }
  public DbSet<Password> Passwords { get; set; }
}
