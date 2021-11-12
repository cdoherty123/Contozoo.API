using Ardalis.GuardClauses;
using Contozoo.API.Interfaces;
using Contozoo.API.Animals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Contozoo.API.Repositories
{
    public class ContozooRepository: IContozooRepository
    {
        private readonly AnimalsContext _dbContext;
    
        public ContozooRepository(AnimalsContext dbContext)
        {
            _dbContext = Guard.Against.Null(dbContext, nameof(dbContext));
        }
        public async Task<ContozooAnimal> GetAnimal(int CAI)
        {
            return await _dbContext.Animals.FindAsync(CAI); 
        }
        public async Task<IEnumerable<ContozooAnimal>> GetAnimals()
        {
            return await _dbContext.Animals.ToListAsync();
        }
        public async Task<bool> AddAnimal(ContozooAnimal contozooAnimal)
        {
            var existingAnimal = await _dbContext.Animals.FindAsync(contozooAnimal.CAI);
            if (existingAnimal == null)
            {
                return false;
            }
            try
            {
                existingAnimal.CAI = contozooAnimal.CAI;
                existingAnimal.Name = contozooAnimal.Name;
                existingAnimal.Location = contozooAnimal.Location;
                existingAnimal.LunchHour = contozooAnimal.LunchHour;    
                existingAnimal.Notes = contozooAnimal.Notes;    
                await _dbContext.SaveChangesAsync();    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
