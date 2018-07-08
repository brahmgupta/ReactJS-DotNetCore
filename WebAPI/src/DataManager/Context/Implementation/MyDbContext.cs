using DataManager.Context.Contracts;
using DataManager.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataManager.Context.Implementation
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<Palindrome> Palindromes { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public async Task Save()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Palindrome>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();
                entity.ToTable("Palindrome");
                entity.Property(e => e.Sequence).IsRequired();
                entity.Property(e => e.CreateDate).IsRequired();
            });
        }
    }
}
