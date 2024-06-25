using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruitsApi.Service
{
    interface IFruitService
    {
        Task<Fruit> GetFruitByName(string name);
        Task<Fruit> AddMetadata(int fruitId, string key, string value);
        Task<Fruit> RemoveMetadata(int fruitId, string key);
        Task<Fruit> UpdateMetadata(int fruitID, string key, string value);
    }
}
