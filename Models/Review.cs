namespace PokemonReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //One relationship will be one object - a Review will have one Reviewer
        public Reviewer Reviewer { get; set; }
        //One relationship will be one object - a Review will be about one Pokemon
        public Pokemon Pokemon { get; set; }
        public int Rating { get; set; }
    }
}
