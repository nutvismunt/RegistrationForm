using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;
using System.IO;
using Xamarin.Essentials;

namespace RegistrationForm.Database
{
    public class RegistrationContext : DbContext
    {
        public DbSet<RegisterForm> RegisterForms { get; set; }

        public RegistrationContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "RegistrationFormDb.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
