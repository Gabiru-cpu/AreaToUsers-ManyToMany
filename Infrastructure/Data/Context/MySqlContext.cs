﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AreaApi.Domain.Models;
using Microsoft.Extensions.Hosting;

namespace AreaApi.Infrastructure.Data.Context
{
    public class MySqlContext : IdentityDbContext<ApplicationUser>
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Area> Area { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<ApplicationRole> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            modelBuilder.Entity<Area>().HasMany(a => a.Users).WithMany(u => u.Areas);

            modelBuilder.Entity<Area>().HasOne(a => a.OwnerUser).WithMany(u => u.AreasOwned);
        }

    }
}
