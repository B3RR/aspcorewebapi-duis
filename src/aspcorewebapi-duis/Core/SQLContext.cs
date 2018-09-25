using System;
using aspcorewebapi_duis.Enums;
using aspcorewebapi_duis.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new FluentAPI.Users(modelBuilder);
            new FluentAPI.Roles(modelBuilder);
            new FluentAPI.Rules(modelBuilder);
            new FluentAPI.Duis(modelBuilder);
            new FluentAPI.RoleUser(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Duis> Duis { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
    }
}