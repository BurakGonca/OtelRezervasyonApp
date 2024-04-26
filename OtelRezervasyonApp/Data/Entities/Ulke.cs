namespace OtelRezervasyonApp.Data.Entities
{
    public class Ulke
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }


        //ulke-sehir  (1-n)
        public ICollection<Sehir>? Sehirler { get; set; }


    }
}
