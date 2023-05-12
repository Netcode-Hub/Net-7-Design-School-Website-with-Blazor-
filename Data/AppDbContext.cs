using Microsoft.EntityFrameworkCore;
using SchoolApp.Logic.Models;

namespace SchoolApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Faq> Questions { get; set; }
    }
}
