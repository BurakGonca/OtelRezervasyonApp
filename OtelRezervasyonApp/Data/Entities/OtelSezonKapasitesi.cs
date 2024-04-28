namespace OtelRezervasyonApp.Data.Entities
{
    public class OtelSezonKapasitesi
    {

        

        public int Id { get; set; }
        public int OtelId { get; set; } //fk
        public Otel? Otel { get; set; } //navig. prop.

        public int SezonId { get; set; } //fk
        public Sezon? Sezon { get; set; } //navig. prop.

        public int OtelSezonKapasite { get; set; }

    }
}
