using System.ComponentModel.DataAnnotations;

namespace OtelRezervasyonApp.Data.Enums
{
    public enum Yildiz
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

}
