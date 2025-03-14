using JobBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Data
{
    public class DataContextEntityFramework : DbContext
    {
        private readonly IConfiguration _config;
        public DataContextEntityFramework(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<JobPost> JobPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JobBoardSchema");

            modelBuilder.Entity<JobPost>().ToTable("job_post").HasKey(post => post.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder configurationBuilder)
        {
            if (configurationBuilder != null)
            {
                configurationBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }
    }
}