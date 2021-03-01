using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Service.Dtos {

    public class DrinkIngredientDto {

        public int DrinkIngredientId { get; set; }
        public int DrinkId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public Ingredient Ingredient { get; set; }

    }

}