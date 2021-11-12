using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ardalis.GuardClauses;
using Contozoo.API.Animals;
using Contozoo.API.Interfaces;
using Contozoo.API.Repositories;

namespace Contozoo.API.Animals
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalsContext _context;
        private readonly IContozooRepository _repository;
        

        public AnimalsController(AnimalsContext context, IContozooRepository repository)
        {
            _context = context;
            _repository = Guard.Against.Null(repository, nameof(repository));
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContozooAnimal>>> GetContozooAnimals()
        {
            var result = await _repository.GetAnimals();
            return Ok(result);
        }

        // GET: api/Animal/5
        [HttpGet("{CAI}")]
        public async Task<ActionResult<ContozooAnimal>> GetAnimal(int CAI)
        {
            var contozooAnimal = await _repository.GetAnimal(CAI);
            if (contozooAnimal == null)
            {
                return NotFound();
            }
            return contozooAnimal;
        }

        // PUT: api/Animal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{CAI}")]
        public async Task<IActionResult> PutAnimals(long CAI, ContozooAnimal animalDTO)
        {
            if (CAI != animalDTO.CAI)
            {
                return BadRequest("Incorrect Contozoo Animal Identification");
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalDTOExists(CAI))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContozooAnimal>> PostAnimals(ContozooAnimal animalDTO)
        {
            _context.Animals.Add(animalDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimals", new { id = animalDTO.CAI }, animalDTO);
        }

        // DELETE: api/Animal/5
        [HttpDelete("{CAI}")]
        public async Task<IActionResult> DeleteAnimal(int CAI)
        {
            var animalDTO = await _context.Animals.FindAsync(CAI);
            if (animalDTO == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animalDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalDTOExists(long CAI)
        {
            return _context.Animals.Any(e => e.CAI == CAI);
        }
    }
}
