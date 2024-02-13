using Microsoft.EntityFrameworkCore;
using RuslanAPI.Core.Models_original;

namespace RuslanAPI.DataLayer.FakeDatabase
{
    public class AppBooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Vartotojas> Users { get; set; }

        public AppBooksDbContext(DbContextOptions<AppBooksDbContext> options) : base(options)
        {
        }
    }
}
