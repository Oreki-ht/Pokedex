using MongoDB.Driver;
using Pokedex.Models;

public class PokemonService : IPokemonService
{
  private readonly IMongoCollection<PokemonModel> _pokemonCollection;
  public PokemonService()
  {
    var client = new MongoClient("mongodb://localhost:27017");
    var database = client.GetDatabase("pokedex");
    _pokemonCollection = database.GetCollection<PokemonModel>("Pokemon");
  }
  public List<PokemonModel> pokemon = new List<PokemonModel> 
  {
    new() {
      Id = "1",
      Name = "Pikachu",
      Type = "Electric",
      Ability = "Static",
      Level = 50
    },
    new() {
      Id = "2",
      Name = "Charmander",
      Type = "Fire",
      Ability = "Blaze",
      Level = 50
    }
  };
  public async Task<List<PokemonModel>> Get()
  {
    return await _pokemonCollection.Find(_ => true).ToListAsync();
  }

  public async Task<PokemonModel?> GetPokemonById(string id)
  {
    return await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
  }

  public async Task<List<PokemonModel>> AddPokemon(PokemonModel newPokemon)
  {
    await _pokemonCollection.InsertOneAsync(newPokemon);
    return await _pokemonCollection.Find(_ => true).ToListAsync();
  }

  public async Task<List<PokemonModel>> UpdatePokemon(string id, PokemonModel updatedPokemon)
  {
    await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);
    return await _pokemonCollection.Find(_ => true).ToListAsync();
  }

  public async Task<List<PokemonModel>> DeletePokemon(string id)
  {
    await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
    return await _pokemonCollection.Find(_ => true).ToListAsync();
  }
}