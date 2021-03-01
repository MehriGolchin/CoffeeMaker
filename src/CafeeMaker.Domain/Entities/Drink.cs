using System.Collections.Generic;

namespace CafeeMaker.Domain.Entities {

    public class Drink {

        private Drink() {
        }
        
        public Drink(int drinkId, string name, string image, IEnumerable<DrinkIngredient> ingredients) {
            DrinkId = drinkId;
            Name = name;
            Image = image;
            Ingredients = ingredients;
        }

        public int DrinkId { get; }
        public string Name { get; }
        public string Image { get; }
        public IEnumerable<DrinkIngredient> Ingredients { get; }

    }

}