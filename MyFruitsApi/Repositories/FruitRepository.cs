using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//It can be done withaout repository pattern, because Entity Framework is being used and only in certan situations can be used.

//https://softwareengineering.stackexchange.com/questions/180851/why-shouldnt-i-use-the-repository-pattern-with-entity-framework, if its needed, here is tha explanation why


public class FruitRepository
{
    private readonly List<Fruit> _fruits = new List<Fruit>();

    public FruitRepository()
    { 
        _fruits = LoadFruits();
    }

    public Task<Fruit> GetFruitByName(string name)
    {
        return Task.FromResult(_fruits.FirstOrDefault(f => f.Name == name));
    }

    public Task<Fruit> GetFruitById(int id)
    {
        return Task.FromResult(_fruits.FirstOrDefault(f => f.Id == id));
    }

    public Task<Fruit> AddMetadata(int fruitId, string key, string value)
    {
        var fruit = _fruits.FirstOrDefault(f => f.Id == fruitId);
        if (fruit != null)
        {
            fruit.Metadata.Add(new FruitMetadata { FruitId = fruitId, Key = key, Value = value });
        }
        return Task.FromResult(fruit);
    }

    public Task RemoveMetadata(int fruitId, string key)
    {
        var fruit = _fruits.FirstOrDefault(f => f.Id == fruitId);
        if (fruit != null)
        {
            var metadataToRemove = fruit.Metadata.FirstOrDefault(m => m.Key == key);
            if (metadataToRemove != null)
            {
                fruit.Metadata.Remove(metadataToRemove);
            }
        }
        return Task.CompletedTask;
    }

    public Task UpdateMetadata(int fruitId, string key, string newValue)
    {
        var fruit = _fruits.FirstOrDefault(f => f.Id == fruitId);
        if (fruit != null)
        {
            var metadataToUpdate = fruit.Metadata.FirstOrDefault(m => m.Key == key);
            if (metadataToUpdate != null)
            {
                metadataToUpdate.Value = newValue;
            }
        }
        return Task.CompletedTask;
    }

    internal Task UpdateFruit(Fruit fruit)
    {
        throw new NotImplementedException();
    }

    private List<Fruit> LoadFruits()
    {
        var fruits = new List<Fruit>
        {
            new Fruit { Id = 1, Name = "Apple", Family = "Rosaceae" },
            new Fruit { Id = 2, Name = "Banana", Family = "Musaceae" },
            
        };
        return fruits;
    }
}