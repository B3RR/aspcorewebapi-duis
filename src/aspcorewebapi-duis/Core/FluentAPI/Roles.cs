using aspcorewebapi_duis.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core.FluentAPI
{
    internal class Roles
    {
        public Roles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.ID);
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Role>().Property(x => x.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Role>().Property(x => x.Description).HasMaxLength(255);
            modelBuilder.Entity<Role>().HasData(
                new Role() {ID = 1,Name = "Admin",Description = "Администратор"},
                new Role() {ID = 2,Name = "User",Description = "Пользователь"});
            
        }
    }
}