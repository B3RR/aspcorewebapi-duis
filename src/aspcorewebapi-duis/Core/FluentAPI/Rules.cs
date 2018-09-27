using aspcorewebapi_duis.Enums;
using aspcorewebapi_duis.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core.FluentAPI
{
    internal class Rules
    {
        public Rules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>().HasKey(x => x.ID);
            modelBuilder.Entity<Rule>().Property(x => x.Controller).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Rule>().Property(x => x.ApplicationName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Rule>().HasIndex(p => new { p.RoleId, p.Controller, p.ApplicationName }).IsUnique();
            modelBuilder.Entity<Rule>().HasData(
                new Rule { ID = 1, DuisId = 15, RoleId = 1, ApplicationName = "aspcorewebapi-duis", Controller = "userinfo" });
        }
    }
}
