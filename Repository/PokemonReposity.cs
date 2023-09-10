using PokemonReview.Data;
using PokemonReview.Dto;
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

        public Pokemon GetPokemon(int pokemonId)
        {
            // Implement the logic to retrieve a Pokemon by its ID from your data source
            return _context.Pokemon.FirstOrDefault(p => p.Id == pokemonId);
        }

        public Pokemon GetPokemon(string pokemonName)
        {
            // Implement the logic to retrieve a Pokemon by its name from your data source
            return _context.Pokemon.FirstOrDefault(p => p.Name.Trim().ToUpper() == pokemonName.Trim().ToUpper());
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();

        }


        public ICollection<Pokemon> GetPokemons()
        {
            //ICollection - ToList() explicit return a list datatype
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
        {
            return GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
