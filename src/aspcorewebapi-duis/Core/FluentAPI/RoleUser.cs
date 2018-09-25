using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core.FluentAPI
{
    internal class RoleUser
    {
        public RoleUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.RoleUser>().HasKey(p => new { p.RoleId, p.UserId });
            modelBuilder.Entity<Models.RoleUser>().HasOne(ru => ru.Role).WithMany(r => r.RoleUsers).HasForeignKey(ru => ru.RoleId);
            modelBuilder.Entity<Models.RoleUser>().HasOne(ru => ru.User).WithMany(u => u.RoleUsers).HasForeignKey(ru => ru.UserId);
            modelBuilder.Entity<Models.RoleUser>().HasData(new Models.RoleUser() { RoleId = 1, UserId = 1 });
        }
    }
}