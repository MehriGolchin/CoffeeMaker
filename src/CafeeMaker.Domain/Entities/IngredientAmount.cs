namespace CafeeMaker.Domain.Entities {

    public class IngredientAmount {

        public IngredientAmount(int drinkIngredientId, int amount) {
            DrinkIngredientId = drinkIngredientId;
            Amount = amount;
        }

        public int DrinkIngredientId { get; } 
        public int Amount { get; }

    }

}