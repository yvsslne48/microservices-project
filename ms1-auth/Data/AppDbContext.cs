using Microsoft.EntityFrameworkCore;
using ms1_auth.Models;

namespace ms1_auth.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}