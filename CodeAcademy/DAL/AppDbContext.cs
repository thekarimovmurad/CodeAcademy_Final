using CodeAcademy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Header> Headers { get; set; }
            public DbSet<WhyUs> whyUs { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Message> Messages { get; set; }
    }
}
