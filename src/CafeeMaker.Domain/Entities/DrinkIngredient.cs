namespace CafeeMaker.Domain.Entities {

    public class DrinkIngredient {

        private DrinkIngredient() {
        }
        
        public DrinkIngredient(int drinkIngredientId, int drinkId, int ingredientId, int amount, Ingredient ingredient) {
            DrinkIngredientId = drinkIngredientId;
            DrinkId = drinkId;
            IngredientId = ingredientId;
            Amount = amount;
            Ingredient = ingredient;
        }

        public int DrinkIngredientId { get; }
        public int DrinkId { get; }
        public int IngredientId { get; }
        public int Amount { get; }
        public Ingredient Ingredient { get; }

    }

}