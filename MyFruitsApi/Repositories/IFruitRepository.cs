﻿using MyFruitsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruitsApi.Repositories
{
    interface IFruitRepository
    {
    Task<Fruit> GetFruitByNameAsync(string name);
        Task AddFruitAsync(Fruit fruit);
        Task UpdateFruitAsync(Fruit fruit);
        Task DeleteFruitAsync(string name);
    }
}