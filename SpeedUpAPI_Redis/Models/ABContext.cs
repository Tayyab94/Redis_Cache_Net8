using Microsoft.EntityFrameworkCore;

namespace SpeedUpAPI_Redis.Models
{
    public class ABContext :DbContext
    {
        public ABContext(DbContextOptions<ABContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                Name = "Tayyab"
            });

            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 2,
                Name = "bhatti"
            });
        }
    }
}
