namespace OtelRezervasyonApp.Data.Entities
{
    public class OtelKapasitesi
    {
        public int Id { get; set; }
        public int OtelId { get; set; } //fk
        public Otel OtelEntity { get; set; } //navig. prop.


    }
}
