using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var baseDate = new DateTime(2025, 11, 5);
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Id = 1, Title = "Went Hiking", Content = "Went hiking with Joe!", Created = baseDate, IsActive = true },
                new DiaryEntry { Id = 2, Title = "Went Shopping", Content = "Went shopping with Joe!", Created = baseDate, IsActive = true },
                new DiaryEntry { Id = 3, Title = "Went Diving", Content = "Went diving with Joe!", Created = baseDate, IsActive = true }
            );
        }

        // Four steps to add a table to our DB
        // 1. Create a Model (DiaryEntry.cs)
        // 2. Add a DbSet<> property to ApplicationDbContext
        // 3. Create a Migration -- open Tools > NuGet Package Manager > Package Manager Console, run : add-migration AddDiaryEntryTable
        // 4. Update the Database -- in the Package Manager Console, run: update-database
        // 2:01:32
    }
}
