using BlogExample.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogExample.Web.Data
{
    public class BlogExampleDbContext : DbContext
    {
        public BlogExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}
