namespace OtelRezervasyonApp.Data.Entities
{
	public class OtelKapasitesi
	{


		public int Id { get; set; }


		public int OtelId { get; set; } //fk
		public Otel? Otel { get; set; } //navig. prop.


		public int OtelToplamKapasite { get; set; }



	}
}
