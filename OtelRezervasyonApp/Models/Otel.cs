using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace OtelRezervasyonApp.Models
{
    public class Otel
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

    public enum Yildiz : short
    {
        [Display(Name = "1 Yıldız")]
        Bir = 1,
        [Display(Name = "2 Yıldız")]
        Iki,
        [Display(Name = "3 Yıldız")]
        Uc,
        [Display(Name = "4 Yıldız")]
        Dort,
        [Display(Name = "5 Yıldız")]
        Bes

    }

    public enum Tur : short
    {
        DevreMulk = 1,
        Apart,
        Butik,
        TatilKoyu,
        YarımPansiyon,
        TamPansiyon,


    }


}
