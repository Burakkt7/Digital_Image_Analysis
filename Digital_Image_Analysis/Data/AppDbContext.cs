using Digital_Image_Analysis.Configuration;
using Digital_Image_Analysis.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_Image_Analysis.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected AppDbContext()
        {
        }
        public DbSet<Image> Images { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Initial Catalog=Digital_Image_Analysis; User Id=sa; Password=Negzel_intern;Trust Server Certificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }
    }
}
