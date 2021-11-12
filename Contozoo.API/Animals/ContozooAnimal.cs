using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Contozoo.API.Animals
{
    public class ContozooAnimal
    {
        [Key]
        public int AnimalId { get; set; }

        //This is Contozoo Animal Identifier/CAI
        public int CAI { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime LunchHour { get; set; }
        public string Notes { get; set; }
    }

}
