﻿using Microsoft.EntityFrameworkCore;
using OtelRezervasyonApp.Data.Entities;
using OtelRezervasyonApp.Models;

namespace OtelRezervasyonApp.Data
{
    public class OtelRezervasyonDbContext : DbContext
    {
        public DbSet<Otel> Oteller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=BURAK;Initial Catalog=OtelRezervasyonDB ;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");

        }

		//ANK-YZLMORT-01\\MSSQLSERVERANK16
        //BURAK

	}
}
