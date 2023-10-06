using ContactBook.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Api.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Contact> contacts { get; set; }
    }
}
