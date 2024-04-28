using Microsoft.EntityFrameworkCore;
using OtelRezervasyonApp.Data.Entities;
using OtelRezervasyonApp.Models;
using System;

namespace OtelRezervasyonApp.Data
{
	public class OtelRezervasyonDbContext : DbContext
	{
		public DbSet<Otel> Oteller { get; set; }
		public DbSet<OtelTuru> OtelTurleri { get; set; }
		public DbSet<OtelOdasi> OtelOdalari { get; set; }
		public DbSet<OtelKapasitesi> OtelKapasiteleri { get; set; }
		public DbSet<OdaTuru> OdaTurleri { get; set; }
		public DbSet<Sezon> Sezonlar { get; set; }
		public DbSet<OtelSezonKapasitesi> OtelSezonKapasiteleri { get; set; }
		public DbSet<Ulke> Ulkeler { get; set; }
		public DbSet<Sehir> Sehirler { get; set; }


		public OtelRezervasyonDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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


			int mevcutYil = DateTime.Now.Year;

			modelBuilder.Entity<Sezon>().HasData
				(
				   new Sezon()
				   {
					   Id = 1,
					   SezonAdi = "Yaz",
					   BaslangicTarihi = new DateTime(mevcutYil, 5, 15),
					   BitisTarihi = new DateTime(mevcutYil, 10, 15)
				   },

				   new Sezon()
				   {
					   Id = 2,
					   SezonAdi = "Kış",
					   BaslangicTarihi = new DateTime(mevcutYil, 10, 15),
					   BitisTarihi = new DateTime(mevcutYil, 5, 15)
				   }

				);



			modelBuilder.Entity<OdaTuru>().HasData(
				  new OdaTuru() { Id = 1, OdaTurAdi = "Single Oda", Aciklama = "Tek Kişilik Oda" },
				  new OdaTuru() { Id = 2, OdaTurAdi = "Double Oda", Aciklama = "Çift Kişilik Oda" },
				  new OdaTuru() { Id = 3, OdaTurAdi = "Triple Oda", Aciklama = "Üç Kişilik Oda" },
				  new OdaTuru() { Id = 4, OdaTurAdi = "Suit Oda", Aciklama = "Lüks Oda" },
				  new OdaTuru() { Id = 5, OdaTurAdi = "Dublex Oda", Aciklama = "İki Katlı Oda" },
				  new OdaTuru() { Id = 6, OdaTurAdi = "Aile Odası", Aciklama = "Aileler İçin Oda" },
				  new OdaTuru() { Id = 7, OdaTurAdi = "Kral Dairesi", Aciklama = "Ultra Lüks Oda" }

			  );


	

		}


	}
}
