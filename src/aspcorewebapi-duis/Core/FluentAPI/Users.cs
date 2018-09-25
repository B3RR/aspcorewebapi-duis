using aspcorewebapi_duis.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core.FluentAPI
{
    internal class Users
    {
        public Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.ID);
            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FIO).HasMaxLength(255);

            modelBuilder.Entity<User>().HasData(
                new User() { ID = 1, Login = "Admin", FIO = "Администратор", Email = "ber.oleg@gmail.com" });

        }
    }
}