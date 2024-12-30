using ElectiveWebApplication.Models;
using ElectiveWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElectiveWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pokemons = await _pokemonService.GetAllPokemonsAsync();
            return Ok(pokemons);
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon([FromBody] Pokemon newPokemon)
        {
            if (newPokemon == null)
                return BadRequest("Pokemon is null.");

            await _pokemonService.AddPokemonAsync(newPokemon);
            return CreatedAtAction(nameof(GetById), new { id = newPokemon.Id }, newPokemon);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null)
                return NotFound("Pokemon not found.");
            return Ok(pokemon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, [FromBody] Pokemon updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest("Pokemon is null.");

            var result = await _pokemonService.UpdatePokemonAsync(id, updatedPokemon);
            if (!result)
                return NotFound("Pokemon not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var result = await _pokemonService.DeletePokemonAsync(id);
            if (!result)
                return NotFound("Pokemon not found.");

            return NoContent();
        }
    }
}
