namespace CafeeMaker.Domain.Entities {

    public class DrinkIngredient {

        private DrinkIngredient() {
        }
        
        public DrinkIngredient(int drinkId, int ingredientId, int amount) {
            DrinkId = drinkId;
            IngredientId = ingredientId;
            Amount = amount;
        }

        public int DrinkId { get; }
        public int IngredientId { get; }
        public int Amount { get; }

    }

}