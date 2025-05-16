using Microsoft.EntityFrameworkCore;
using CampusNewsAPI.Models;

namespace CampusNewsAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> NewsPosts { get; set; }
}