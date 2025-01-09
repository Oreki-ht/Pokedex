using Pokedex.Models;

public interface IPokemonService
{
    Task<List<PokemonModel>> Get();
    Task<PokemonModel?> GetPokemonById(string id);
    Task<List<PokemonModel>> AddPokemon(PokemonModel newPokemon);
    Task<List<PokemonModel>> UpdatePokemon(string id, PokemonModel updatedPokemon);
    Task<List<PokemonModel>> DeletePokemon(string id);
}