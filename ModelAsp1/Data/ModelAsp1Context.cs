﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelAsp1.Models;

namespace ModelAsp1.Data
{
    public class ModelAsp1Context : DbContext
    {
        public ModelAsp1Context (DbContextOptions<ModelAsp1Context> options)
            : base(options)
        {
        }

        public DbSet<ModelAsp1.Models.Product> Product { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlite(@"Data Source=C:\Users\DELL\Desktop\DESKTOP\ILISI 3\C# asp.NET\LAB\Data Bases\Achat.db");

        public DbSet<ModelAsp1.Models.User> User { get; set; } = default!;
    }
}
