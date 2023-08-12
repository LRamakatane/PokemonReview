namespace PokemonReview.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Many relationship will be a list - a Reviewer can have many Reviews
        public ICollection<Review> Reviews { get; set; }

    }
}
