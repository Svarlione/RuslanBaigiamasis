using RuslanAPI.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RuslanAPI.DataLayer.FakeDatabase
{
    public class AppBooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public AppBooksDbContext(DbContextOptions<AppBooksDbContext> options) : base(options)
        {
        }
    }
}
