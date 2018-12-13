using System;
using Microsoft.EntityFrameworkCore;

namespace BrighterTestDb
{
        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=blogging.db");
            }
        }
}