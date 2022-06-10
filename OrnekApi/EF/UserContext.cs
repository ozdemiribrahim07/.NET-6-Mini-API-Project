using Microsoft.EntityFrameworkCore;
using OrnekApi.Models;

namespace OrnekApi.EF
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {
        }
    }
}
