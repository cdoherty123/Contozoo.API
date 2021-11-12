using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contozoo.API.Animals;

namespace Contozoo.API.Animals
{
    public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options ) : base(options)
        {

        }
        //db set is needed with the api name then the model then the table name then get and set
        public DbSet<Contozoo.API.Animals.ContozooAnimal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        { 
        
        }
           
    }
}
