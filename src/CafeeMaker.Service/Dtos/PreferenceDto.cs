using System.Collections.Generic;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Service.Dtos {

    public class DrinkPreferenceDto {

        public IEnumerable<(int DrinkIngredientId, int Amount)> Amounts { get; set; }
        public Mug Mug { get; }

    }

}