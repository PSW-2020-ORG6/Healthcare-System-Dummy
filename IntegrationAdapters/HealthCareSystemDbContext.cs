﻿using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters
{
    public class HealthCareSystemDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }

        public HealthCareSystemDbContext(DbContextOptions<HealthCareSystemDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
    }
