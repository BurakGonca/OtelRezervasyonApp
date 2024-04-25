using OtelRezervasyonApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OtelRezervasyonApp.Data.Entities
{
    public class OtelEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string? Aciklama { get; set; }
        public Tur Turu { get; set; }
        public Yildiz Yildizi { get; set; }
        public string Adres { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Telefon { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? Logo { get; set; }

    }
}
