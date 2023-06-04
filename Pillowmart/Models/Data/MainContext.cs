using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pillowmart.Models.Data;

public class MainContext : IdentityDbContext<User>
{
    public DbSet<User> Users { get; set; }
    
    public MainContext(DbContextOptions options) : base(options)
    {
    }
}