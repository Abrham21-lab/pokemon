using ElectiveWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectiveWebApplication.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly List<Pokemon> _pokemons;

        public PokemonService()
        {
            _pokemons = new List<Pokemon>
            {
                new Pokemon { Id = 1, Name = "Pikachu", Type = "Electric", Level = 10 },
                new Pokemon { Id = 2, Name = "Charmander", Type = "Fire", Level = 8 },
                new Pokemon { Id = 3, Name = "Bulbasaur", Type = "Grass", Level = 7 }
            };
        }

        public async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            return await Task.FromResult(_pokemons);
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            return await Task.FromResult(_pokemons.FirstOrDefault(p => p.Id == id));
        }

        public async Task<List<Pokemon>> GetPokemonsByTypeAsync(string type)
        {
            return await Task.FromResult(_pokemons.Where(p => p.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        public async Task AddPokemonAsync(Pokemon pokemon)
        {
            if (pokemon != null)
            {
                pokemon.Id = _pokemons.Any() ? _pokemons.Max(p => p.Id) + 1 : 1;
                _pokemons.Add(pokemon);
                await Task.CompletedTask;
            }
        }

        public async Task<bool> UpdatePokemonAsync(int id, Pokemon updatedPokemon)
        {
            var pokemon = _pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon != null && updatedPokemon != null)
            {
                pokemon.Name = updatedPokemon.Name;
                pokemon.Type = updatedPokemon.Type;
                pokemon.Level = updatedPokemon.Level;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            var pokemon = _pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon != null)
            {
                _pokemons.Remove(pokemon);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
