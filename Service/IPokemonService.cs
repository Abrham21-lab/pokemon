using ElectiveWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectiveWebApplication.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemonsAsync();
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task<List<Pokemon>> GetPokemonsByTypeAsync(string type);
        Task AddPokemonAsync(Pokemon pokemon);
        Task<bool> UpdatePokemonAsync(int id, Pokemon updatedPokemon);
        Task<bool> DeletePokemonAsync(int id);
    }
}
