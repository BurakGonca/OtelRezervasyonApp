using Microsoft.EntityFrameworkCore;
using OtelRezervasyonApp.Data.Entities;
using OtelRezervasyonApp.Models;

namespace OtelRezervasyonApp.Data
{
    public class OtelRezervasyonDbContext : DbContext
    {
        public DbSet<Otel> Oteller { get; set; }
        public DbSet<OtelTuru> OtelTurleri { get; set; }
        public DbSet<OtelOdasi> OtelOdalari { get; set; }
        public DbSet<OtelKapasitesi> OtelKapasiteleri { get; set; }

        public DbSet<Ulke> Ulkeler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }



        public OtelRezervasyonDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Data Source=BURAK;Initial Catalog=OtelRezervasyonDB ;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");

        //}

        //ANK-YZLMORT-01\\MSSQLSERVERANK16
        //BURAK



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OtelOdasi>().HasKey(od => new { od.OdaId, od.OtelId });

        }


    }
}
