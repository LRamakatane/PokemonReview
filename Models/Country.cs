namespace PokemonReview.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Many relationship will be a list - a Country can have many Owners located in it
        public ICollection<Owner> Owners { get; set; }
    }
}
