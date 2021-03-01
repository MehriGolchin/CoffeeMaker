using System.Collections.Generic;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Service.Dtos {

    public class DrinkDto {

        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }

}