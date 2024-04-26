using OtelRezervasyonApp.Data.Enums;
using OtelRezervasyonApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OtelRezervasyonApp.Data.Entities
{
    public class Otel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string? Aciklama { get; set; }

        public int OtelTuruId { get; set; }
        public OtelTuru OtelTuru { get; set; }

        public Yildiz Yildizi { get; set; }
        public string Adres { get; set; }


        public int UlkeId { get; set; }
        public Ulke Ulke { get; set; }

        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? Logo { get; set; }




        



    }
}
