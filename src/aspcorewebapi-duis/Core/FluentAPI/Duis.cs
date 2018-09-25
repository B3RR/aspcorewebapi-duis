using System;
using System.Collections.Generic;
using System.Linq;
using aspcorewebapi_duis.Enums;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Core.FluentAPI
{
    public class Duis
    {
        public Duis(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Duis>().HasIndex(x => x.ID);
            modelBuilder.Entity<Models.Duis>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Models.Duis>().Property(x => x.Name).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<Models.Duis>().Property(x => x.Description).HasMaxLength(100);

            foreach (DuisEnum duis in Enum.GetValues(typeof(DuisEnum)))
            {
                if (duis != DuisEnum.None)
                    modelBuilder.Entity<Models.Duis>().HasData(new Models.Duis()
                    {
                        ID = (int)duis,
                        Name = duis.ToString(),
                        Description = Helpers.EnumsHelper.GetEnumFieldText(duis)
                    });
            }
        }
    }
}