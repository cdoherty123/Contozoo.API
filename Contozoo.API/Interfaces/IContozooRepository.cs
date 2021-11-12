using Contozoo.API.Animals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.API.Interfaces
{
    public interface IContozooRepository
    {
        public Task <IEnumerable<ContozooAnimal>> GetAnimals();
        public Task<ContozooAnimal> GetAnimal(int CAI);
        public Task<bool> AddAnimal(ContozooAnimal contozooAnimal);

        //public Task<IActionResult> DeleteAnimal(int CAI);
    }
}
