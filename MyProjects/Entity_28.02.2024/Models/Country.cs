namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public virtual Continent Continent { get; set; } // Making Continent virtual

    }
}
