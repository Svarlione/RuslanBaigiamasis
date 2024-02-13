using RuslanAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Image = RuslanAPI.Core.Models.Image;
using Microsoft.Extensions.Configuration;

namespace RuslanAPI.DataLayer.Data
{
    public class UserDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<LoginInfo> LoginInfo { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {

        }
    }
}
