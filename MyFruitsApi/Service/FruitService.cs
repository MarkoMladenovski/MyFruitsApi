using MyFruitsApi.Repositories;
using MyFruitsApi.Service;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class FruitService : IFruitService
{
    private readonly HttpClient _httpClient;
    private readonly FruitRepository _fruitRepository;

    public FruitService(HttpClient httpClient, IFruitRepository fruitRepository)
    {
        _httpClient = httpClient;
        _fruitRepository = (FruitRepository)fruitRepository;
    }

    public async Task<Fruit> GetFruitByName(string name)
    {
        var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{name}");
        if (response.IsSuccessStatusCode)
        {
            var cachedFruit = await _fruitRepository.GetFruitByNameAsync(name);
            if (cachedFruit != null)
            {
                return cachedFruit;
            }
            //var fruitJson = await response.Content.ReadAsStringAsync();
            //var fruit = JsonSerializer.Deserialize<Fruit>(fruitJson);
            //return fruit;
        }
        else
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception($"Fruit '{name}' not found.");
            }
            else
            {
                throw new Exception($"Error fetching fruit: {name} - Status Code: {response.StatusCode}");
            }
        }
    }

    public async Task<Fruit> AddMetadata(int fruitId, string key, string value)
    {
        var fruit = await _fruitRepository.GetFruitById(fruitId);
        if (fruit == null)
        {
            throw new Exception($"Fruit with ID {fruitId} not found.");
        }

        var newMetadata = new FruitMetadata { FruitId = fruitId, Key = key, Value = value };
        fruit.Metadata.Add(newMetadata);
        await _fruitRepository.UpdateFruit(fruit);
        return fruit;
    }

    public async Task<Fruit> RemoveMetadata(int fruitId, string key)
    {
        var fruit = await _fruitRepository.GetFruitById(fruitId);
        if (fruit == null)
        {
            throw new Exception($"Fruit with ID {fruitId} not found.");
        }

        var metadataToRemove = fruit.Metadata.FirstOrDefault(m => m.Key == key);
        if (metadataToRemove != null)
        {
            fruit.Metadata.Remove(metadataToRemove);
            await _fruitRepository.UpdateFruit(fruit);
        }
        return fruit;
    }

    public async Task<Fruit> UpdateMetadata(int fruitId, string key, string newValue)
    {
        
        var fruit = await _fruitRepository.GetFruitById(fruitId);
        if (fruit == null)
        {
            throw new Exception($"Fruit with ID {fruitId} not found.");
        }

        var metadataToUpdate = fruit.Metadata.FirstOrDefault(m => m.Key == key);
        if (metadataToUpdate != null)
        {
            metadataToUpdate.Value = newValue;
            await _fruitRepository.UpdateFruit(fruit);
        }
        return fruit;
    }
}