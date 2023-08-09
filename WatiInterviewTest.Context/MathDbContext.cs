using Microsoft.EntityFrameworkCore;
using WatiInterviewTest.Model;

namespace WatiInterviewTest.Context
{
    public class MathDbContext: DbContext
    {
        public MathDbContext(DbContextOptions<MathDbContext> options) : base(options) { }

        public DbSet<Sum> tblSum {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sum>();
            base.OnModelCreating(modelBuilder);
        }

    }
}