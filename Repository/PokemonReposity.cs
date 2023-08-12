using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class PokemonReposity : IPokemonRepository
    {
        private readonly DataContext _context;
        //ctor for contructors
        public PokemonReposity(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            //ICollection - ToList() explicit return a list datatype
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }
    }
}
