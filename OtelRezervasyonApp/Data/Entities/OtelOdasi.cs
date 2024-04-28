using Microsoft.EntityFrameworkCore.Metadata;
using OtelRezervasyonApp.Data.Enums;

namespace OtelRezervasyonApp.Data.Entities
{
    public class OtelOdasi
    {
        public int OdaId { get; set; }

        public int OtelId { get; set; } //fk
        public Otel? Otel { get; set; } //navig. prop.


        public short OdaNumarasi { get; set; }
        public Kat BulunduguKat { get; set; }
        public short? OdaOlcusuM2 { get; set; }
        public byte OdaKapasitesi { get; set; }


        public int OdaTuruId { get; set; } //fk
        public OdaTuru? OdaTuru { get; set; } //navig. prop.


    }



}
